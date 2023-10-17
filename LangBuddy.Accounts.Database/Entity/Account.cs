using LangBuddy.Accounts.Database.Entity.Common;

namespace LangBuddy.Accounts.Database.Entity
{
    public class Account: EntityBase
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public long? UserId { get; set; }
    }
}
