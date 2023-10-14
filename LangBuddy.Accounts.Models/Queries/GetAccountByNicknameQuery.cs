using LangBuddy.Accounts.Database.Entity;
using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetAccountByNicknameQuery(string Nickname) : IRequest<Account>;
}
