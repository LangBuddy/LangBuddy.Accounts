using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class DeleteAccountByIdCommand: IDeleteAccountByIdCommand
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly IGetAccountByIdCommand _getAccountByIdCommand;
        public DeleteAccountByIdCommand(AccountsDbContext accountsDbContext,
            IGetAccountByIdCommand getAccountByIdCommand) 
        {
            _accountsDbContext = accountsDbContext;
            _getAccountByIdCommand = getAccountByIdCommand;
        }

        public async Task<int> Invoke(long id)
        {
            var account = await _getAccountByIdCommand.Invoke(id);

            if(account == null)
            {
                throw new ArgumentNullException("The account was not found");
            }

            account.SeDeleteTime();

            _accountsDbContext.Update(account);

            return await _accountsDbContext.SaveChangesAsync();
        }
    }
}
