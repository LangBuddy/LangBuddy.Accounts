using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CheckingIdCommand: ICheckingIdCommand
    {
        private readonly IGetAccountByIdCommand _getAccountByIdCommand;
        
        public CheckingIdCommand(IGetAccountByIdCommand getAccountByIdCommand)
        {
            _getAccountByIdCommand = getAccountByIdCommand;
        }
        public async Task<Database.Entity.Account> Invoke(long id)
        {
            var account = await _getAccountByIdCommand.Invoke(id);

            if (account == null)
            {
                throw new ArgumentNullException("The account was not found");
            }

            return account;
        }
    }
}
