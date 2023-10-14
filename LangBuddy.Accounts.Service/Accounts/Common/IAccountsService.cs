using LangBuddy.Accounts.Models.Request;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IAccountsService
    {
        Task<IEnumerable<Database.Entity.Account>> GetAll();

        Task Create(AccountCreateRequest accountCreateRequest);

        Task Delete(long id);

        Task Update(long id, AccountUpdateRequest accountUpdateRequest);

        Task<Models.Dto.AccountPasswordHashResponse> GetPasswordHash(string email);
    }
}
