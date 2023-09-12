using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class GetAccountByEmailCommand: IGetAccountByEmailCommand
    {
        private readonly AccountsDbContext accountsDbContext;

        public GetAccountByEmailCommand(AccountsDbContext accountsDbContext)
        {
            this.accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account?> Invoke(string email)
        {
            var account = await accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.DeleteDate == null);

            return account;
        }
    }
}
