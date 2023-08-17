namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IGetAccountByNicknameCommand
    {
        Task<Database.Entity.Account?> Invoke(string nickname);
    }
}
