namespace LangBuddy.Accounts.Models.Responses
{
    public record HttpResponse(
        bool Success,
        string Message,
        object? Data
    );
}
