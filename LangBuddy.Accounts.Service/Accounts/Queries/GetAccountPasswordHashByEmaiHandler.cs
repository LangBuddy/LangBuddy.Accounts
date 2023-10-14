using LangBuddy.Accounts.Models.Dto;
using LangBuddy.Accounts.Models.Queries;
using LangBuddy.Accounts.Service.Mappers;
using MediatR;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetAccountPasswordHashByEmaiHandler : IRequestHandler<GetAccountPasswordHashByEmailQuery, AccountPasswordHashResponse>
    {
        private readonly IMediator _mediator;

        public GetAccountPasswordHashByEmaiHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<AccountPasswordHashResponse> Handle(GetAccountPasswordHashByEmailQuery request, CancellationToken cancellationToken)
        {
            var accountByEmail = await _mediator.Send(new GetAccountByEmailQuery(request.Email));

            return accountByEmail.ToAccountPasswordHashDto();
        }
    }
}
