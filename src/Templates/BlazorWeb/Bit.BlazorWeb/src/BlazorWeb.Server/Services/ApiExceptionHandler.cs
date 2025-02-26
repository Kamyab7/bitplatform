﻿using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;

namespace BlazorWeb.Server.Services;

public partial class ApiExceptionHandler : IExceptionHandler
{
    [AutoInject] private IWebHostEnvironment webHostEnvironment = default!;
    [AutoInject] private IStringLocalizer<AppStrings> localizer = default!;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception e, CancellationToken cancellationToken)
    {
        // Using the Request-Id header, one can find the log for server-related exceptions
        httpContext.Response.Headers.Append("Request-ID", httpContext.TraceIdentifier);

        var exception = UnWrapException(e);
        var knownException = exception as KnownException;

        // The details of all of the exceptions are returned only in dev mode. in any other modes like production, only the details of the known exceptions are returned.
        var key = knownException?.Key ?? nameof(UnknownException);
        var message = knownException?.Message ?? (webHostEnvironment.IsDevelopment() ? exception.Message : localizer[nameof(UnknownException)]);

        var statusCode = (int)(exception is RestException restExp ? restExp.StatusCode : HttpStatusCode.InternalServerError);

        if (exception is KnownException && message == key)
        {
            message = localizer[message];
        }

        var restExceptionPayload = new RestErrorInfo
        {
            Key = key,
            Message = message,
            ExceptionType = knownException?.GetType().FullName ?? typeof(UnknownException).FullName
        };

        if (exception is ResourceValidationException validationException)
        {
            restExceptionPayload.Payload = validationException.Payload;
        }

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(restExceptionPayload, AppJsonContext.Default.RestErrorInfo, cancellationToken: cancellationToken);

        return true;
    }

    private Exception UnWrapException(Exception exp)
    {
        return exp is TargetInvocationException && exp.InnerException is not null
            ? exp.InnerException
            : exp;
    }
}
