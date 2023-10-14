using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetHasEmailHandler : IRequestHandler<GetHasEmailQuery, bool>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetHasEmailHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<bool> Handle(GetHasEmailQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Email.Equals(request.Email) && x.DeleteDate == null);

            if (account != null)
            {
                throw new ArgumentException("Email is already in use");
            }

            return true;
        }
    }
}
