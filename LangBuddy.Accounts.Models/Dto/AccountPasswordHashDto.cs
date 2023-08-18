using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Models.Dto
{
    public record AccountPasswordHashDto(
        byte[] PasswordSalt, byte[] PasswordHash
    );
}
