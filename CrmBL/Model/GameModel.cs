using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class GameModel
    {
        Random rnd = new Random();
        Generator Generator = new Generator();
        List<Task> tasks = new List<Task>();
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        public List<Bosses> Bossess { get; set; } = new List<Bosses>();
        public List<Dungeon> Dungeons { get; set; } = new List<Dungeon>();
        public List<Drop> Drops { get; set; } = new List<Drop>();
        public List<Loot> Loots { get; set; } = new List<Loot>();
        public Queue<Player> Players { get; set; } = new Queue<Player>();

        public int CharacterSpeed { get; set; } = 100;
        public int DungeonClean { get; set; } = 100;

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
            tasks.Add(new Task(() => CreateDungeon(4, token)));
            tasks.AddRange(Bossess.Count((b => new Task(() => CreateDungeon(b, token)))));

            foreach(var task in tasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            cancelTokenSource.Cancel();
            Thread.Sleep(1000);
        }

        private void BossesWork(Bosses bosses, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (bosses.Count > 0)
                {
                    bosses.Dequeue();
                    Thread.Sleep(DungeonClean);
                }
            }
        }

        public void CreateDungeon(int characterCount, CancellationToken token)
        {

            while (!token.IsCancellationRequested)
            {
                var characters = Generator.GetNewCharacters(10);

                foreach (var character in characters)
                {
                    var dunges = new Queue<Dungeon>();

                    foreach(var item in Generator.GetRandomItem(4, 11))
                    {
                        dunges.Add(item);
                    }

                    var boss = Bossess[rnd.Next(Bossess.Count - 1)];
                }

                Thread.Sleep(CharacterSpeed);
            }
        }
    }
}
