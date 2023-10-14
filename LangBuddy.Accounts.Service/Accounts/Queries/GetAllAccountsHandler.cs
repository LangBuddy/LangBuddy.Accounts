using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Database.Entity.Account>>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetAllAccountsHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<IEnumerable<Database.Entity.Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
            => await _accountsDbContext.Accounts
                .Where(x => x.DeleteDate == null)
                .ToListAsync();
    }
}
