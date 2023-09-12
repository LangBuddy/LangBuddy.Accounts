namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface ICheckingEmailCommand
    {
        Task<Database.Entity.Account?> Invoke(string email);
    }
}
