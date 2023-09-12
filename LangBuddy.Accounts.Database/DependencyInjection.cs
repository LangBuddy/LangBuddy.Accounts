using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangBuddy.Accounts.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AccountsDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    options => options.UseNodaTime());
            });

            services.AddScoped<AccountsDbContext>();

            return services;
        }
    }
}
