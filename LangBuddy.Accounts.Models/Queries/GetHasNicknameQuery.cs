using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetHasNicknameQuery(string Nickname) : IRequest<bool>;
}
