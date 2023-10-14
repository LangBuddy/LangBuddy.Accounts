using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetAccountByEmailHandler : IRequestHandler<GetAccountByEmailQuery, Database.Entity.Account>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAccountByEmailHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Email.Equals(request.Email) && x.DeleteDate == null);

            if (account == null)
            {
                throw new ArgumentNullException("The account was not found");
            }

            return account;
        }
    }
}
