using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IAccountService
    {
        Task<List<Database.Entity.Account>> GetAll();

        Task<int> Create(AccountCreateRequest accountCreateRequest);

        Task<int> Delete(long id);

        Task<int> Update(long id, AccountUpdateRequest accountUpdateRequest);
    }
}
