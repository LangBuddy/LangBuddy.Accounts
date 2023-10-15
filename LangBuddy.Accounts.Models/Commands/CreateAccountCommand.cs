using MediatR;

namespace LangBuddy.Accounts.Models.Commands
{
    public record CreateAccountCommand(string Email, string Nickname, byte[] PasswordSalt, byte[] PasswordHash) : IRequest<long>;
}
