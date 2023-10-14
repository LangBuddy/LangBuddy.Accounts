using LangBuddy.Accounts.Database.Entity;
using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetAccountByEmailQuery(string Email) : IRequest<Account>;
}
