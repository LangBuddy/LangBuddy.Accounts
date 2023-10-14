using LangBuddy.Accounts.Database.Entity;
using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetAccountByIdQuery(long Id) : IRequest<Account>;
}
