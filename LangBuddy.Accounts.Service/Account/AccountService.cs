using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IDeleteAccountByIdCommand _deleteAccountByIdCommand;
        private readonly IUpdateAccountCommand _updateAccountCommand;
        private readonly IGetAllAccountsCommand _getAllAccountsCommand;
        public AccountService(ICreateAccountCommand createAccountCommand,
            IDeleteAccountByIdCommand deleteAccountByIdCommand,
            IUpdateAccountCommand updateAccountCommand,
            IGetAllAccountsCommand getAllAccountsCommand) 
        {
            _createAccountCommand = createAccountCommand;
            _deleteAccountByIdCommand = deleteAccountByIdCommand;
            _updateAccountCommand = updateAccountCommand;
            _getAllAccountsCommand = getAllAccountsCommand;
        }

        public async Task<List<Database.Entity.Account>> GetAll()
        {
            return await _getAllAccountsCommand.Invoke();
        }

        public async Task<int> Create(AccountCreateRequest accountCreateRequest)
        {
            return await _createAccountCommand.Invoke(accountCreateRequest);
        }

        public async Task<int> Delete(long id)
        {
            return await _deleteAccountByIdCommand.Invoke(id);
        }

        public async Task<int> Update(long id, AccountUpdateRequest accountUpdateRequest)
        {
            return await _updateAccountCommand.Invoke(id, accountUpdateRequest);
        }
    }
}
