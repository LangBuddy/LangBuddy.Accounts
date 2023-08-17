using LangBuddy.Accounts.Service.Account;
using LangBuddy.Accounts.Service.Account.Commands;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangBuddy.Accounts.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGetAccountByEmailCommand, GetAccountByEmailCommand>();
            services.AddTransient<IGetAccountByNicknameCommand, GetAccountByNicknameCommand>();
            services.AddTransient<IGetAccountByIdCommand,  GetAccountByIdCommand>();
            services.AddTransient<ICheckingEmailCommand, CheckingEmailCommand>();
            services.AddTransient<ICheckingNicknameCommand, CheckingNicknameCommand>();
            services.AddTransient<ICheckingIdCommand, CheckingIdCommand>();

            services.AddTransient<ICreateAccountCommand, CreateAccountCommand>();
            services.AddTransient<IDeleteAccountByIdCommand, DeleteAccountByIdCommand>();
            services.AddTransient<IUpdateAccountCommand, UpdateAccountCommand>();
            services.AddTransient<IGetAllAccountsCommand, GetAllAccountsCommand>();

            services.AddTransient<IAccountService, AccountService>();

            return services;
        }
    }
}