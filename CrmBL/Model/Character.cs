using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Loot> Loots { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
