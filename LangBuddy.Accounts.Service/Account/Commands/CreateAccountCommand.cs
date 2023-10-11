using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;
using LangBuddy.Accounts.Service.Mappers;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly ICheckingEmailCommand _checkingEmailCommand;
        private readonly ICheckingNicknameCommand _checkingNicknameCommand;

        public CreateAccountCommand(AccountsDbContext accountsDbContext,
            ICheckingEmailCommand checkingEmailCommand,
            ICheckingNicknameCommand checkingNicknameCommand)
        {
            _accountsDbContext = accountsDbContext;
            _checkingEmailCommand = checkingEmailCommand;
            _checkingNicknameCommand = checkingNicknameCommand;
        }

        public async Task<int> Invoke(AccountCreateRequest accountCreateRequest)
        {
            await _checkingEmailCommand.Invoke(accountCreateRequest.Email);

            await _checkingNicknameCommand.Invoke(accountCreateRequest.Nickname);

            var account = accountCreateRequest.ToModel();
            account.SetCreateTime();

            await _accountsDbContext.Accounts.AddAsync(account);

            return await _accountsDbContext.SaveChangesAsync();
        }
    }
}
