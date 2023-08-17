using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Models.Request
{
    public record AccountCreateRequest(
        string Email, string Nickname, byte[] PasswordSalt, byte[] PasswordHash
    );
}
