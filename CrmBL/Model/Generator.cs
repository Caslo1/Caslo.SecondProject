using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Generator
    {
        Random rnd = new Random();

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Character> Characters { get; set; } = new List<Character>();

        public List<Character> GetNewCharacters(int count)
        {
            var result = new List<Character>();

            for (int i = 0; i < count; i++)
            {
                var character = new Character()
                {
                    CharacterId = Characters.Count,
                    Name = GetRandomText()
                };
                Characters.Add(character);

                result.Add(character);
            }

            return result;
        }

        public List<Player> GetNewPlayer(int count)
        {
            var result = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                var player = new Player()
                {
                    PlayerId = Players.Count,
                    Name = GetRandomText()
                };
                Players.Add(player);

                result.Add(player);
            }

            return result;
        }

        public List<Item> GetNewItem(int count)
        {
            var result = new List<Item>();

            for (int i = 0; i < count; i++)
            {
                var item = new Item()
                {
                    ItemId = Items.Count,
                    Name = GetRandomText(),
                    Count = rnd.Next(1, 10),
                    DropChance = Convert.ToDecimal(rnd.Next(1, 100) +  rnd.NextDouble())
                };
                Items.Add(item);

                result.Add(item);
            }

            return result;
        }

        public List<Item> GetRandomItem(int min, int max)
        {
            var result = new List<Item>();

            var count = rnd.Next(min, max);

            for(int i = 0; i < count; i++)
            {
                result.Add(Items[rnd.Next(Items.Count - 1)]);
            }

            return result;
        }

        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
