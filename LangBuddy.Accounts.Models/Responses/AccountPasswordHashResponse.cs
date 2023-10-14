namespace LangBuddy.Accounts.Models.Dto
{
    public record AccountPasswordHashResponse(
        byte[] PasswordSalt, byte[] PasswordHash
    );
}
