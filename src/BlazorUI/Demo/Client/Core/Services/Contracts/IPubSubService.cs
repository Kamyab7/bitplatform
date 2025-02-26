﻿namespace Bit.BlazorUI.Demo.Client.Core.Services.Contracts;

public interface IPubSubService
{
    void Pub(string message, object? payload);
    Action Sub(string message, Action<object?> handler);
}
