using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Database.Entity.Common
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? DeleteDate { get; set; } = null;

        public void SetCreateTime()
        {
            CreateDate = DateTime.UtcNow;
        }

        public void SeDeleteTime()
        {
            DeleteDate = DateTime.UtcNow;
        }

        public void SetUpdateTime()
        {
            UpdateDate = DateTime.UtcNow;
        }

    }
}
