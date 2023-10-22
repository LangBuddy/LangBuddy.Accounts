namespace LangBuddy.Accounts.Models.Responses
{
    public record AccountPasswordHashResponse(
        byte[] PasswordSalt, byte[] PasswordHash
    );
}
