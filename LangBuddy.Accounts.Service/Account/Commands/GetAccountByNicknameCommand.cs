using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class GetAccountByNicknameCommand : IGetAccountByNicknameCommand
    {
        private readonly AccountsDbContext accountsDbContext;

        public GetAccountByNicknameCommand(AccountsDbContext accountsDbContext)
        {
            this.accountsDbContext = accountsDbContext;
        }

        public async Task<Database.Entity.Account?> Invoke(string nickname)
        {
            var account = await accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Nickname == nickname && x.DeleteDate == null);

            return account;
        }
    }
}
