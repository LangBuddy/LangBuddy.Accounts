namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IDeleteAccountByIdCommand
    {
        Task<int> Invoke(long id);
    }
}
