using LangBuddy.Accounts.Models.Dto;
using LangBuddy.Accounts.Models.Request;
using Mapster;

namespace LangBuddy.Accounts.Service.Mappers
{
    public static class AccountMapper
    {
        public static Database.Entity.Account ToModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Database.Entity.Account>();
        }

        public static AccountPasswordHashDto ToAccountPasswordHashDto(this Database.Entity.Account account)
        {
            return account.Adapt<AccountPasswordHashDto>();
        }
    }
}
