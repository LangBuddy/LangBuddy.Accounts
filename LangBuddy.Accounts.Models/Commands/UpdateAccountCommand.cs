using MediatR;

namespace LangBuddy.Accounts.Models.Commands
{
    public class UpdateAccountCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Nickname { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public long? UserId { get; set; }
    }
}
