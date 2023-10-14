using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Service.Account;
using LangBuddy.Accounts.Service.Account.Commands;
using LangBuddy.Accounts.Service.Account.Common;
using LangBuddy.Accounts.Service.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LangBuddy.Accounts.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<AccountCreateRequestValidator>();
            services.AddScoped<AccountUpdateRequestValidator>();

            services.AddTransient<IAccountsService, AccountsService>();

            return services;
        }
    }
}