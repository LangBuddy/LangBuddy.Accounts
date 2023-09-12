using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface ICreateAccountCommand
    {
        Task<int> Invoke(AccountCreateRequest accountCreateRequest);
    }
}
