﻿using LangBuddy.Accounts.Models.Mappers;
using LangBuddy.Accounts.Service.Account.Common;

namespace LangBuddy.Accounts.Service.Account.Commands
{
    public class AccountPasswordHashByEmailCommand : IAccountPasswordHashByEmailCommand
    {
        private readonly ICheckingEmailCommand _checkingEmailCommand;

        public AccountPasswordHashByEmailCommand(ICheckingEmailCommand checkingEmailCommand)
        {
            _checkingEmailCommand = checkingEmailCommand;
        }

        public async Task<Models.Dto.AccountPasswordHashDto> Invoke(string email)
        {
            var res = await _checkingEmailCommand.Invoke(email);
            return res.ToAccountPasswordHashDto();
        }
    }
}
