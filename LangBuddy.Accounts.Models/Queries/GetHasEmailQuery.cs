using MediatR;

namespace LangBuddy.Accounts.Models.Queries
{
    public record GetHasEmailQuery(string Email) : IRequest<bool>;
}
