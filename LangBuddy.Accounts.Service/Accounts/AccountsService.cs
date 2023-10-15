using FluentValidation;
using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Queries;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Models.Responses;
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

        public async Task<HttpResponse> GetAll()
        {
            var res = await _mediator.Send(new GetAllAccountsQuery());

            return new HttpResponse(true, "Successfully get", res.ToArray());
        }

        public async Task<HttpResponse> Create(AccountCreateRequest accountCreateRequest)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(accountCreateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            var res = await _mediator.Send(accountCreateRequest.ToCommand());

            return new HttpResponse(true, "Successfully created", new
            {
                Id = res
            });
        }

        public async Task<HttpResponse> Delete(long id)
        {
            var res = await _mediator.Send(new DeleteAccountByIdCommand(id));

            return new HttpResponse(true, "Successfully deleted", new
            {
                Id = res
            });
        }

        public async Task<HttpResponse> Update(long id, AccountUpdateRequest accountUpdateRequest)
        {
            var validResult = await _accountUpdateRequestValidator.ValidateAsync(accountUpdateRequest);

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            var res = await _mediator.Send(accountUpdateRequest.ToCommand(id));

            return new HttpResponse(true, "Successfully updated", new
            {
                Id = res
            });
        }

        public async Task<HttpResponse> GetPasswordHash(string email)
        {
            var validResult = await _accountCreateRequestValidator.ValidateAsync(
                new AccountCreateRequest(email, "1", new byte[] { 1 }, new byte[] { 1 }));

            if (!validResult.IsValid)
            {
                throw new ValidationException(validResult.Errors);
            }

            var res = await _mediator.Send(new GetAccountPasswordHashByEmailQuery(email));

            return new HttpResponse(true, "Successfully updated", res);
        }
    }
}
