using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Queries;
using MediatR;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class DeleteAccountByIdHandler : IRequestHandler<DeleteAccountByIdCommand>
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly IMediator _mediator;
        public DeleteAccountByIdHandler(AccountsDbContext accountsDbContext,
            IMediator mediator)
        {
            _accountsDbContext = accountsDbContext;
            _mediator = mediator;
        }

        public async Task Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery(request.Id));

            account.SeDeleteTime();

            _accountsDbContext.Update(account);

            await _accountsDbContext.SaveChangesAsync();
        }
    }
}
