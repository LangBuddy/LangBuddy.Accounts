using LangBuddy.Accounts.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Database
{
    public class AccountsDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options) 
        {
            Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}