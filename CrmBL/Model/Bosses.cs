using System.Collections.Generic;
using System.Net;

namespace CrmBL.Model
{
    public class Bosses
    {
        CrmContext db = new CrmContext(); 
        public string Name { get; set; }
        public Player Player { get; set; }
        public Queue<Dungeon> Queue { get; set; }
        public bool KillBoss { get; set; }
        public int Count => Queue.Count;

        public Bosses(string name, Player player)
        {
            Name = name;
            Player = player;
            Queue = new Queue<Dungeon>();
            KillBoss = false;
        }

        public void exp()
        {
            var loot = Queue.Dequeue();
            var drop = new Drop();

            if(KillBoss)
            {
                db.Drops.Add(drop);
                db.SaveChanges();
            }
            else
            {
                drop.DropId = 0;
            }

            var items = new List<Item>();

            foreach(Item item in loot)
            {
                if (item.Count == 10)
                {

                    if (KillBoss)
                    {
                        db.Items.Add(item);
                    }

                    item.Count++;
                }
            }

            if (KillBoss)
            {
                db.SaveChanges();
            }

        }
    }
}
