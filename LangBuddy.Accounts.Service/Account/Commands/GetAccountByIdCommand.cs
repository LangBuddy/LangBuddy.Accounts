using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class GetAccountByIdCommand: IGetAccountByIdCommand
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAccountByIdCommand(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account?> Invoke(long id)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Id == id && x.DeleteDate == null);

            return account;
        }
    }
}
