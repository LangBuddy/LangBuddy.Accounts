using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Queries;
using MediatR;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly AccountsDbContext _accountsDbContext;
        public UpdateAccountHandler(IMediator mediator,
            AccountsDbContext accountsDbContext)
        {
            _mediator = mediator;
            _accountsDbContext = accountsDbContext;
        }

        public async Task<long> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery(request.Id));

            if (request.Email != null)
            {
                await _mediator.Send(new GetHasEmailQuery(request.Email));

                account.Email = request.Email;
            }

            if (request.Nickname != null)
            {
                await _mediator.Send(new GetHasNicknameQuery(request.Nickname));
                account.Nickname = request.Nickname;
            }

            if (request.PasswordHash != null && request.PasswordSalt != null)
            {
                account.PasswordHash = request.PasswordHash;
                account.PasswordSalt = request.PasswordSalt;
            }

            if (request.UserId != null)
            {
                account.UserId = request.UserId;
            }

            account.SetUpdateTime();

            _accountsDbContext.Update(account);

            await _accountsDbContext.SaveChangesAsync();

            return account.Id;
        }
    }
}
