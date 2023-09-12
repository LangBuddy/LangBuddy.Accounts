namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IGetAllAccountsCommand
    {
        Task<List<Database.Entity.Account>> Invoke();
    }
}
