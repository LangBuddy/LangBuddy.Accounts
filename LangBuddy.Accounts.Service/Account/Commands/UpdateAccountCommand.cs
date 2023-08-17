using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class UpdateAccountCommand : IUpdateAccountCommand
    {
        private readonly ICheckingEmailCommand _checkingEmailCommand;
        private readonly ICheckingNicknameCommand _checkingNicknameCommand;
        private readonly ICheckingIdCommand _checkingIdCommand;
        private readonly AccountsDbContext _accountsDbContext;
        public UpdateAccountCommand(ICheckingEmailCommand checkingEmailCommand,
            ICheckingNicknameCommand checkingNicknameCommand,
            ICheckingIdCommand checkingIdCommand,
            AccountsDbContext accountsDbContext) 
        {
            _checkingEmailCommand = checkingEmailCommand;
            _checkingNicknameCommand = checkingNicknameCommand;
            _checkingIdCommand = checkingIdCommand;
            _accountsDbContext = accountsDbContext;
        }

        public async Task<int> Invoke(long id, AccountUpdateRequest accountUpdateRequest)
        {
            var account = await _checkingIdCommand.Invoke(id);

            if (accountUpdateRequest.Email != null)
            {
                await _checkingEmailCommand.Invoke(accountUpdateRequest.Email);

                account.Email = accountUpdateRequest.Email;
            }

            if (accountUpdateRequest.Nickname != null)
            {
                await _checkingNicknameCommand.Invoke(accountUpdateRequest.Nickname);

                account.Nickname = accountUpdateRequest.Nickname;
            }

            if(accountUpdateRequest.PasswordHash != null && accountUpdateRequest.PasswordSalt != null)
            {
                account.PasswordHash = accountUpdateRequest.PasswordHash;
                account.PasswordSalt = accountUpdateRequest.PasswordSalt;
            }

            account.SetUpdateTime();

            _accountsDbContext.Update(account);

            return await _accountsDbContext.SaveChangesAsync();
        }
    }
}
