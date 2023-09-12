namespace LangBuddy.Accounts.Models.Dto
{
    public record AccountPasswordHashDto(
        byte[] PasswordSalt, byte[] PasswordHash
    );
}
