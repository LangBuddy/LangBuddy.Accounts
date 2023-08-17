using System;
namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IGetAccountByEmailCommand
    {
        Task<Database.Entity.Account?> Invoke(string email);
    }
}
