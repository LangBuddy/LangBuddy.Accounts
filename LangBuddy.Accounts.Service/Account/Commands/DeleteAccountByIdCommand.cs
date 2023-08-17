using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class DeleteAccountByIdCommand: IDeleteAccountByIdCommand
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly ICheckingIdCommand _checkingIdCommand;
        public DeleteAccountByIdCommand(AccountsDbContext accountsDbContext,
            ICheckingIdCommand checkingIdCommand) 
        {
            _accountsDbContext = accountsDbContext;
            _checkingIdCommand = checkingIdCommand;
        }

        public async Task<int> Invoke(long id)
        {
            var account = await _checkingIdCommand.Invoke(id);

            account.SeDeleteTime();

            _accountsDbContext.Update(account);

            return await _accountsDbContext.SaveChangesAsync();
        }
    }
}
