namespace LangBuddy.Accounts.Models.Request
{
    public record AccountCreateRequest(
        string Email, string Nickname, byte[] PasswordSalt, byte[] PasswordHash, long? UserId = null
    );
}
