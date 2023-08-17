using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class GetAllAccountsCommand : IGetAllAccountsCommand
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAllAccountsCommand(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<List<Database.Entity.Account>> Invoke()
        {
            return await _accountsDbContext.Accounts
                .Where(x => x.DeleteDate == null)
                .ToListAsync();
        }
    }
}
