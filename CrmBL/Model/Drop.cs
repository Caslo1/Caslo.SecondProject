namespace CrmBL.Model
{
    public class Drop
    {
        public int DropId { get; set; }
        public int LootId { get; set; }
        public int ItemId { get; set; }

        public virtual Loot Loot { get; set; }
        public virtual Item Item { get; set; }
    }
}
