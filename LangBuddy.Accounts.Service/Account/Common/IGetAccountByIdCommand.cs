namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IGetAccountByIdCommand
    {
        Task<Database.Entity.Account?> Invoke(long id);
    }
}
