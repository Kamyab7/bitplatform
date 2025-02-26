﻿//-:cnd:noEmit
using BlazorWeb.Shared.Dtos.Identity;

namespace BlazorWeb.Client.Pages.Identity;

[Authorize]
public partial class EditProfilePage
{
    private bool isSaving;
    private bool isRemoving;
    private bool isLoading;
    private string? profileImageUrl;
    private string? profileImageError;
    private string? editProfileMessage;
    private string? profileImageUploadUrl;
    private string? profileImageRemoveUrl;
    private BitMessageBarType editProfileMessageType;
    private UserDto user = new();
    private readonly EditUserDto userToEdit = new();
    private bool isDeleteAccountConfirmModalOpen;

    protected override async Task OnInitAsync()
    {
        isLoading = true;

        try
        {
            await LoadEditProfileData();

            var access_token = await PrerenderStateService.GetValue($"{nameof(EditProfilePage)}-access_token", AuthTokenProvider.GetAccessTokenAsync);

            profileImageUploadUrl = $"{Configuration.GetApiServerAddress()}Attachment/UploadProfileImage?access_token={access_token}";
            profileImageUrl = $"{Configuration.GetApiServerAddress()}Attachment/GetProfileImage?access_token={access_token}";
            profileImageRemoveUrl = $"Attachment/RemoveProfileImage?access_token={access_token}";
        }
        finally
        {
            isLoading = false;
        }

        await base.OnInitAsync();
    }

    private async Task LoadEditProfileData()
    {
        user = await GetCurrentUser() ?? new();

        UpdateEditProfileData();
    }

    private async Task RefreshProfileData()
    {
        await LoadEditProfileData();

        PubSubService.Publish(PubSubMessages.PROFILE_UPDATED, user);
    }

    private void UpdateEditProfileData()
    {
        userToEdit.Gender = user.Gender;
        userToEdit.FullName = user.FullName;
        userToEdit.BirthDate = user.BirthDate;
    }

    private Task<UserDto?> GetCurrentUser() => PrerenderStateService.GetValue($"{nameof(EditProfilePage)}-{nameof(user)}", () => HttpClient.GetFromJsonAsync("User/GetCurrentUser", AppJsonContext.Default.UserDto));

    private async Task DoSave()
    {
        if (isSaving) return;

        isSaving = true;
        editProfileMessage = null;

        try
        {
            user.FullName = userToEdit.FullName;
            user.BirthDate = userToEdit.BirthDate;
            user.Gender = userToEdit.Gender;

            (await (await HttpClient.PutAsJsonAsync("User/Update", userToEdit, AppJsonContext.Default.EditUserDto))
                .Content.ReadFromJsonAsync(AppJsonContext.Default.UserDto))!.Patch(user);

            PubSubService.Publish(PubSubMessages.PROFILE_UPDATED, user);

            editProfileMessageType = BitMessageBarType.Success;
            editProfileMessage = Localizer[nameof(AppStrings.ProfileUpdatedSuccessfullyMessage)];
        }
        catch (KnownException e)
        {
            editProfileMessageType = BitMessageBarType.Error;

            editProfileMessage = e.Message;
        }
        finally
        {
            isSaving = false;
        }
    }

    private async Task RemoveProfileImage()
    {
        if (isRemoving) return;

        isRemoving = true;

        try
        {
            await HttpClient.DeleteAsync(profileImageRemoveUrl);

            await RefreshProfileData();
        }
        catch (KnownException e)
        {
            editProfileMessage = e.Message;
            editProfileMessageType = BitMessageBarType.Error;
        }
        finally
        {
            isRemoving = false;
        }
    }
}
