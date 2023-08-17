namespace LangBuddy.Accounts.Models.Request
{
    public record AccountUpdateRequest(
        string? Email, string? Nickname, byte[]? PasswordSalt, byte[]? PasswordHash
    );
}
