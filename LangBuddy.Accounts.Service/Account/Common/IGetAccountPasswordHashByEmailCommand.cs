using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Service.Account.Common
{
    public interface IGetAccountPasswordHashByEmailCommand
    {
        Task<Models.Dto.AccountPasswordHashDto> Invoke(string email);
    }
}
