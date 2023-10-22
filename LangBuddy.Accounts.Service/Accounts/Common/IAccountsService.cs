using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Models.Responses;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IAccountsService
    {
        Task<HttpResponse> GetAll();

        Task<HttpResponse> GetByEmail(string email);

        Task<HttpResponse> Create(AccountCreateRequest accountCreateRequest);

        Task<HttpResponse> Delete(long id);

        Task<HttpResponse> Update(long id, AccountUpdateRequest accountUpdateRequest);

        Task<HttpResponse> GetPasswordHash(string email);
    }
}
