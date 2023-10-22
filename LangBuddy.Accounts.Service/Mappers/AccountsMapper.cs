using LangBuddy.Accounts.Models.Commands;
using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Models.Responses;
using Mapster;

namespace LangBuddy.Accounts.Service.Mappers
{
    public static class AccountsMapper
    {
        public static Database.Entity.Account ToModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Database.Entity.Account>();
        }

        public static Database.Entity.Account ToModel(this CreateAccountCommand accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Database.Entity.Account>();
        }

        public static AccountPasswordHashResponse ToAccountPasswordHashDto(this Database.Entity.Account account)
        {
            return account.Adapt<AccountPasswordHashResponse>();
        }

        public static CreateAccountCommand ToCommand(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<CreateAccountCommand>();
        }

        public static UpdateAccountCommand ToCommand(this AccountUpdateRequest accountCreateRequest, long id)
        {
            var updateAccountCommand = accountCreateRequest.Adapt<UpdateAccountCommand>();
            updateAccountCommand.Id = id;
            return updateAccountCommand;
        }

        public static AccountResponse ToResponse(this Database.Entity.Account account)
        {
            return account.Adapt<AccountResponse>();
        }
    }
}
