using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CheckingNicknameCommand: ICheckingNicknameCommand
    {
        private readonly IGetAccountByNicknameCommand _getAccountByNicknameCommand;

        public CheckingNicknameCommand(IGetAccountByNicknameCommand getAccountByNicknameCommand)
        {
            _getAccountByNicknameCommand = getAccountByNicknameCommand;
        }

        public async Task Invoke(string nickname)
        {
            var accountByNickname = await _getAccountByNicknameCommand.Invoke(nickname);

            if (accountByNickname != null)
            {
                throw new ArgumentException("Nickname is already in use");
            }
        }
    }
}
