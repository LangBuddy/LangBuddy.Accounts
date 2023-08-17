namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface ICheckingIdCommand
    {
        Task<Database.Entity.Account> Invoke(long id);
    }
}
