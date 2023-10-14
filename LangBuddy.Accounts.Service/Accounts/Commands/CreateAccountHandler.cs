using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Queries;
using LangBuddy.Accounts.Service.Mappers;
using MediatR;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly IMediator _mediator;

        public CreateAccountHandler(AccountsDbContext accountsDbContext,
            IMediator mediator)
        {
            _accountsDbContext = accountsDbContext;
            _mediator = mediator;
        }
        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new GetHasEmailQuery(request.Email));

            await _mediator.Send(new GetHasNicknameQuery(request.Nickname));

            var account = request.ToModel();
            account.SetCreateTime();

            await _accountsDbContext.Accounts.AddAsync(account);

            await _accountsDbContext.SaveChangesAsync();
        }
    }
}
