using LangBuddy.Accounts.Database.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Database.Entity
{
    public class Account: EntityBase
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
