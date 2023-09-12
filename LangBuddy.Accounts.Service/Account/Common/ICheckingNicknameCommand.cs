namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface ICheckingNicknameCommand
    {
        Task Invoke(string nickname);
    }
}
