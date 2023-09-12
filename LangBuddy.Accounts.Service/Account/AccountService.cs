using FluentValidation;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;
using LangBuddy.Accounts.Service.Validators;

namespace LangBuddy.Accounts.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IDeleteAccountByIdCommand _deleteAccountByIdCommand;
        private readonly IUpdateAccountCommand _updateAccountCommand;
        private readonly IGetAllAccountsCommand _getAllAccountsCommand;
        private readonly IGetAccountPasswordHashByEmailCommand _getAccountPasswordHashByEmailCommand;
        private readonly AccountCreateRequestValidator _accountCreateRequestValidator;
        private readonly AccountUpdateRequestValidator _accountUpdateRequestValidator;
        public AccountService(ICreateAccountCommand createAccountCommand,
            IDeleteAccountByIdCommand deleteAccountByIdCommand,
            IUpdateAccountCommand updateAccountCommand,
            IGetAllAccountsCommand getAllAccountsCommand,
            IGetAccountPasswordHashByEmailCommand getAccountPasswordHashByEmailCommand,
            AccountCreateRequestValidator accountCreateRequestValidator,
            AccountUpdateRequestValidator accountUpdateRequestValidator) 
        {
            _createAccountCommand = createAccountCommand;
            _deleteAccountByIdCommand = deleteAccountByIdCommand;
            _updateAccountCommand = updateAccountCommand;
            _getAllAccountsCommand = getAllAccountsCommand;
            _getAccountPasswordHashByEmailCommand = getAccountPasswordHashByEmailCommand;
            _accountCreateRequestValidator = accountCreateRequestValidator;
            _accountUpdateRequestValidator = accountUpdateRequestValidator;
        }

        public async Task<List<Database.Entity.Account>> GetAll()
        {
            return await _getAllAccountsCommand.Invoke();
        }

        public async Task<int> Create(AccountCreateRequest accountCreateRequest)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(accountCreateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _createAccountCommand.Invoke(accountCreateRequest);
        }

        public async Task<int> Delete(long id)
        {
            return await _deleteAccountByIdCommand.Invoke(id);
        }

        public async Task<int> Update(long id, AccountUpdateRequest accountUpdateRequest)
        {
            var validResult = await _accountUpdateRequestValidator.ValidateAsync(accountUpdateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _updateAccountCommand.Invoke(id, accountUpdateRequest);
        }

        public async Task<Models.Dto.AccountPasswordHashDto> GetPasswordHash(string email)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(
                new AccountCreateRequest(email, "1", new byte[] { 1 }, new byte[] { 1 }));

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _getAccountPasswordHashByEmailCommand.Invoke(email);
        }
    }
}
