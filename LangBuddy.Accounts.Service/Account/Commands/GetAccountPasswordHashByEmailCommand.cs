using LangBuddy.Accounts.Models.Mappers;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class GetAccountPasswordHashByEmailCommand : IGetAccountPasswordHashByEmailCommand
    {
        private readonly IGetAccountByEmailCommand _getAccountByEmailCommand;

        public GetAccountPasswordHashByEmailCommand(IGetAccountByEmailCommand getAccountByEmailCommand)
        {
            _getAccountByEmailCommand = getAccountByEmailCommand;
        }

        public async Task<Models.Dto.AccountPasswordHashDto> Invoke(string email)
        {
            var res = await _getAccountByEmailCommand.Invoke(email);

            if (res == null)
            {
                throw new ArgumentException("Email is not already in use");
            }

            return res.ToAccountPasswordHashDto();
        }
    }
}
