using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmBL.Model
{
    public class GameModel
    {
        Random rnd = new Random();
        Generator Generator = new Generator();
        public List<Bosses> Bossess { get; set; } = new List<Bosses>();
        public List<Drop> Drops { get; set; } = new List<Drop>();
        public List<Loot> Loots { get; set; } = new List<Loot>();
        public Queue<Player> Players { get; set; } = new Queue<Player>();

        public GameModel()
        {
            var players = Generator.GetNewPlayer(10);
            Generator.GetNewItem(11);
            Generator.GetNewCharacters(10);

            foreach(var player in players)
            {
                Players.Enqueue(player);
            }

            for(int i = 0; i < 2; i++)
            {
                Bossess.Add(new Bosses(Convert.ToString(Bossess.Count), Players.Dequeue()));
            }
        }

        public void Start()
        {
            var characters = Generator.GetNewCharacters(10);

            var dunges = new Queue<Dungeon>();

            foreach(var character in characters)
            {
                var dung = new Dungeon(character);

                foreach(var item in Generator.GetRandomItem(5, 11))
                {
                    dung.Add(item);
                }

                dunges.Enqueue(dung);
            }

            while (dunges.Count > 0)
            {
                var boss = Bossess[rnd.Next(Bossess.Count - 1)];
                dunges.Dequeue();
            }

            while(true)
            {
                var boss = Bossess[rnd.Next(Bossess.Count - 1)];
            }
        }
    }
}
