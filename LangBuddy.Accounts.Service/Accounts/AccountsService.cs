using FluentValidation;
using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Queries;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;
using LangBuddy.Accounts.Service.Mappers;
using LangBuddy.Accounts.Service.Validators;
using MediatR;

namespace LangBuddy.Accounts.Service.Account
{
    public class AccountsService : IAccountsService
    {
        private readonly AccountCreateRequestValidator _accountCreateRequestValidator;
        private readonly AccountUpdateRequestValidator _accountUpdateRequestValidator;
        private readonly IMediator _mediator;
        public AccountsService(AccountCreateRequestValidator accountCreateRequestValidator,
            AccountUpdateRequestValidator accountUpdateRequestValidator,
            IMediator mediator) 
        {
            _accountCreateRequestValidator = accountCreateRequestValidator;
            _accountUpdateRequestValidator = accountUpdateRequestValidator;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Database.Entity.Account>> GetAll()
        {

            return await _mediator.Send(new GetAllAccountsQuery());
        }

        public async Task Create(AccountCreateRequest accountCreateRequest)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(accountCreateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            await _mediator.Send(accountCreateRequest.ToCommand());
        }

        public async Task Delete(long id)
        {
            await _mediator.Send(new DeleteAccountByIdCommand(id));
        }

        public async Task Update(long id, AccountUpdateRequest accountUpdateRequest)
        {
            var validResult = await _accountUpdateRequestValidator.ValidateAsync(accountUpdateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            await _mediator.Send(accountUpdateRequest.ToCommand(id));
        }

        public async Task<Models.Dto.AccountPasswordHashResponse> GetPasswordHash(string email)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(
                new AccountCreateRequest(email, "1", new byte[] { 1 }, new byte[] { 1 }));

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            return await _mediator.Send(new GetAccountPasswordHashByEmailQuery(email));
        }
    }
}
