using LangBuddy.Accounts.Models.Dto;
using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetAccountPasswordHashByEmailQuery(string Email) : IRequest<AccountPasswordHashResponse>;
}
