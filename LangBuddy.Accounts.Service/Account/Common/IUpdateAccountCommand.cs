using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IUpdateAccountCommand
    {
        Task<int> Invoke(long id, AccountUpdateRequest accountUpdateRequest);
    }
}
