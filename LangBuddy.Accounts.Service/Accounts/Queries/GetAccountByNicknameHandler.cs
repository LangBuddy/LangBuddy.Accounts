using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetAccountByNicknameHandler : IRequestHandler<GetAccountByNicknameQuery, Database.Entity.Account>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAccountByNicknameHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account> Handle(GetAccountByNicknameQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Nickname.Equals(request.Nickname) && x.DeleteDate == null);

            if (account == null)
            {
                throw new ArgumentNullException("The account was not found");
            }

            return account;
        }
    }
}
