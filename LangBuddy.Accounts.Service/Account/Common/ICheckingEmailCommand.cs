namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface ICheckingEmailCommand
    {
        Task Invoke(string email);
    }
}
