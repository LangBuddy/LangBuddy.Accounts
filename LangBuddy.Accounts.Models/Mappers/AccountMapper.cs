using LangBuddy.Accounts.Database.Entity;
using LangBuddy.Accounts.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Models.Mappers
{
    public class AccountMapper
    {
        public static Account ToModel(this AccountCreateRequest accountCreateRequest)
        {
            return accountCreateRequest.Adapt<Account>();
        }
    }
}
