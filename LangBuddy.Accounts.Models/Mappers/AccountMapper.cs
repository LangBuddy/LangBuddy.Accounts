using LangBuddy.Accounts.Database.Entity;
using LangBuddy.Accounts.Models.Dto;
using LangBuddy.Accounts.Models.Request;
using Mapster;

namespace LangBuddy.Accounts.Models.Mappers
{
    public static class AccountMapper
    {
        public static Account ToModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Account>();
        }

        public static AccountPasswordHashDto ToAccountPasswordHashDto(this Account account)
        {
            return account.Adapt<AccountPasswordHashDto>();
        }
    }
}
