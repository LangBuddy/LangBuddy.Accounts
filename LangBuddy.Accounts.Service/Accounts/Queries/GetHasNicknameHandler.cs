using LangBuddy.Accounts.Database;
using LangBuddy.Accounts.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangBuddy.Accounts.Service.Account.Queries
{
    public class GetHasNicknameHandler : IRequestHandler<GetHasNicknameQuery, bool>
    {
        private readonly AccountsDbContext _accountsDbContext;

        public GetHasNicknameHandler(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public async Task<bool> Handle(GetHasNicknameQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountsDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Nickname.Equals(request.Nickname) && x.DeleteDate == null);

            if (account != null)
            {
                throw new ArgumentException("Nickname is already in use");
            }

            return true;
        }
    }
}
