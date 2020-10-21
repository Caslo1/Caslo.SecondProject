using System.Data.Entity;

namespace CrmBL.Model
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("CrmConnection") { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Loot> Loots { get; set; }
        public DbSet<Drop> Drops { get; set; }
    }
}
