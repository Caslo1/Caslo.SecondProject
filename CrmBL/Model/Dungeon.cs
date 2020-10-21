using System.Collections;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Dungeon : IEnumerable
    {
        public Character Character { get; set; }
        public Dictionary<Item, int> Items { get; set; }

        public Dungeon(Character character)
        {
            Character = character;
            Items = new Dictionary<Item, int>();
        }

        public void Add(Item item)
        {
            if(Items.TryGetValue(item, out int count ))
            {
                Items[item] = ++count;
            }
            else
            {
                Items.Add(item, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var item in Items.Keys)
            {
                for(int i = 0; i < Items[item]; i++)
                {
                    yield return item;
                }
            }
        }

        public List<Item> GetAll()
        {
            var result = new List<Item>();
            foreach(Item i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
