﻿using System.Text;
using System.Text.Json;
using BlazorWeb.Shared.Dtos.Identity;

namespace BlazorWeb.Client.Services;

public partial class AppAuthenticationManager : AuthenticationStateProvider
{
    [AutoInject] private IAuthTokenProvider tokenProvider = default!;
    [AutoInject] private HttpClient httpClient = default;
    [AutoInject] private IJSRuntime jsRuntime = default!;

    public async Task SignIn(SignInRequestDto signInModel)
    {
        var result = await (await httpClient.PostAsJsonAsync("Identity/SignIn", signInModel, AppJsonContext.Default.SignInRequestDto))
                .Content.ReadFromJsonAsync(AppJsonContext.Default.TokenResponseDto);

        await jsRuntime.StoreAuthToken(result!, signInModel.RememberMe);

        NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
    }

    public async Task SignOut()
    {
        await jsRuntime.RemoveAuthTokens();
        NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
    }

    public async Task RefreshToken()
    {
        await jsRuntime.RemoveCookie("access_token");
        NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var access_token = await tokenProvider.GetAccessTokenAsync();

        if (string.IsNullOrEmpty(access_token) && tokenProvider.IsInitialized)
        {
            string? refresh_token = await jsRuntime.GetLocalStorage("refresh_token");

            if (string.IsNullOrEmpty(refresh_token) is false)
            {
                // We refresh the access_token to ensure a seamless user experience, preventing unnecessary 'NotAuthorized' page redirects and improving overall UX.
                // This method is triggered after 401 and 403 server responses in AuthDelegationHandler,
                // as well as when accessing pages without the required permissions in NotAuthorizedPage, ensuring that any recent claims granted to the user are promptly reflected.

                try
                {
                    var refreshTokenResponse = await (await httpClient.PostAsJsonAsync("Identity/Refresh", new() { RefreshToken = refresh_token }, AppJsonContext.Default.RefreshRequestDto))
                        .Content.ReadFromJsonAsync(AppJsonContext.Default.TokenResponseDto);

                    await jsRuntime.StoreAuthToken(refreshTokenResponse!);
                    access_token = refreshTokenResponse!.AccessToken;
                }
                catch (ResourceValidationException exp) // refresh_token in invalid or expired
                {
                    await jsRuntime.RemoveAuthTokens();
                    throw new UnauthorizedException(nameof(AppStrings.YouNeedToSignIn), exp);
                }
            }
        }

        if (string.IsNullOrEmpty(access_token))
        {
            return NotSignedIn();
        }

        var identity = new ClaimsIdentity(claims: ParseTokenClaims(access_token), authenticationType: "Bearer", nameType: "name", roleType: "role");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    private static AuthenticationState NotSignedIn()
    {
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    private static IEnumerable<Claim> ParseTokenClaims(string access_token)
    {
        return ParseJwt(access_token)
            .Select(keyValue => new Claim(keyValue.Key, keyValue.Value.ToString() ?? string.Empty))
            .ToArray();
    }

    private static Dictionary<string, object> ParseJwt(string access_token)
    {
        // Split the token to get the payload
        string base64UrlPayload = access_token.Split('.')[1];

        // Convert the payload from Base64Url format to Base64
        string base64Payload = ConvertBase64UrlToBase64(base64UrlPayload);

        // Decode the Base64 string to get a JSON string
        string jsonPayload = Encoding.UTF8.GetString(Convert.FromBase64String(base64Payload));

        // Deserialize the JSON string to a dictionary
        var claims = JsonSerializer.Deserialize(jsonPayload, AppJsonContext.Default.DictionaryStringObject)!;

        return claims;
    }

    private static string ConvertBase64UrlToBase64(string base64Url)
    {
        base64Url = base64Url.Replace('-', '+').Replace('_', '/');

        // Adjust base64Url string length for padding
        switch (base64Url.Length % 4)
        {
            case 2:
                base64Url += "==";
                break;
            case 3:
                base64Url += "=";
                break;
        }

        return base64Url;
    }
}
