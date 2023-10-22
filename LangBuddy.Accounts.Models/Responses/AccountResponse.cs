namespace LangBuddy.Accounts.Models.Responses
{
    public record AccountResponse
    (
        string Email,
        string Nickname,
        long? UserId
    );
}
