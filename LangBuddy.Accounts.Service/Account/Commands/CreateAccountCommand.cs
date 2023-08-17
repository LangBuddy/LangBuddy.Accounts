using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Mappers;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly AccountsDbContext _accountsDbContext;
        private readonly IGetAccountByEmailCommand _getAccountByEmailCommand;
        private readonly IGetAccountByNicknameCommand _getAccountByNicknameCommand;

        public CreateAccountCommand(AccountsDbContext accountsDbContext,
            IGetAccountByEmailCommand getAccountByEmailCommand,
            IGetAccountByNicknameCommand getAccountByNicknameCommand)
        {
            _accountsDbContext = accountsDbContext;
            _getAccountByEmailCommand = getAccountByEmailCommand;
            _getAccountByNicknameCommand = getAccountByNicknameCommand;
        }

        public async Task<int> Invoke(AccountCreateRequest accountCreateRequest)
        {
            var accountByEmail = await _getAccountByEmailCommand.Invoke(accountCreateRequest.Email);
            var accountByNickname = await _getAccountByNicknameCommand.Invoke(accountCreateRequest.Nickname);

            if(accountByEmail != null) 
            {
                throw new ArgumentException("Email is already in use");
            }

            if (accountByNickname != null)
            {
                throw new ArgumentException("Nickname is already in use");
            }

            var account = accountCreateRequest.ToModel();
            account.SetCreateTime();

            await _accountsDbContext.Accounts.AddAsync(account);

            return await _accountsDbContext.SaveChangesAsync();
        }
    }
}
