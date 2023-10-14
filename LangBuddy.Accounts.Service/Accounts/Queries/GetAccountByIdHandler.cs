using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, Database.Entity.Account>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAccountByIdHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.DeleteDate == null);

            if (account == null)
            {
                throw new ArgumentNullException("The account was not found");
            }

            return account;
        }
    }
}
