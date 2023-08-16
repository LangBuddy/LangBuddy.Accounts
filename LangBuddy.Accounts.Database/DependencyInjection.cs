using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangBuddy.Accounts.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //"Server=localhost;Port=6789;Database=MiniChatDataBase;Username=postgres;Password=123456"

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
