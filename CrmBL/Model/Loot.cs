using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Loot
    {
        public int LootId { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public DateTime droploot { get; set; }
        public virtual ICollection<Drop> Drops { get; set; }

        public override string ToString()
        {
            return $"{LootId} drop in {droploot}";
        }
    }
}
