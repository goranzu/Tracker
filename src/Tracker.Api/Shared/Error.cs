namespace Tracker.Api.Shared;

public sealed class Error
{
    public string Message { get; }
    public int StatusCode { get; }

    public Error(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
};