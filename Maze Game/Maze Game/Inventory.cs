using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class Inventory
    {

        private List<Item> _items = new List<Item>();

        //-----------------------------------------------------------------------------------------------------
        public Inventory()
        {

        }

        //-----------------------------------------------------------------------------------------------------
        public void Dispose()
        {
            _items.Clear();
        }

        //-----------------------------------------------------------------------------------------------------
        public bool has_item(string id)
        {

            if (fetch(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public void put(Item item)
        {
            _items.Add(item);
        }

        //-----------------------------------------------------------------------------------------------------
        public Item take(string id)
        {
            Item s;

            foreach (Item i in _items)
            {
                if (i.are_you_a(id))
                {
                    s = i;
                    _items.Remove(i);
                    return s;
                }
            }

            return null;
        }

        //-----------------------------------------------------------------------------------------------------
        public Item fetch(string id)
        {

            foreach (Item i in _items)
            {
                if (i.are_you_a(id))
                    return i;
            }

            return null;
        }

        //-----------------------------------------------------------------------------------------------------
        public string list_items()
        {
            string s = "";

            foreach (Item i in _items)
            {
                s += "\t" + i.get_short_desc() + "\n";
            }

            return s;
        }
    }

}

