using LangBuddy.Accounts.Models.Responses;
using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetAccountPasswordHashByEmailQuery(string Email) : IRequest<AccountPasswordHashResponse>;
}
