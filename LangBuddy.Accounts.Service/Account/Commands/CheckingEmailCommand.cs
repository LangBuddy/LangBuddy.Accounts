using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CheckingEmailCommand: ICheckingEmailCommand
    {
        private readonly IGetAccountByEmailCommand _getAccountByEmailCommand;

        public CheckingEmailCommand(IGetAccountByEmailCommand getAccountByEmailCommand)
        {
            _getAccountByEmailCommand = getAccountByEmailCommand;
        }

        public async Task Invoke(string email)
        {
            var accountByEmail = await _getAccountByEmailCommand.Invoke(email);

            if (accountByEmail != null)
            {
                throw new ArgumentException("Email is already in use");
            }
        }
    }
}
