using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal DropChance { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Drop> Drops { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return ItemId;
        }

        public override bool Equals(object obj)
        {
            if(obj is Item item)
            {
                return ItemId.Equals(item.ItemId);
            }

            return false;
        }
    }
}
