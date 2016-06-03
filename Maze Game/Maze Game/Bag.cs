using System.Collections.Generic;

namespace Maze_Game
{
    public class Bag : Item, IHaveInventory
    {

        //-----------------------------------------------------------------------------------------------------
        public Bag(List<string> ids, string name, string desc)
            : base(new List<string>(ids), name, desc)
        {

            _inventory = new Inventory();
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual GameObj locate(string id)
        {

            if (this.are_you_a(id))
            {
                return this;
            }

            else if (_inventory.has_item(id))
            {
                return _inventory.fetch(id);
            }

            else
            {
                return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public override string get_name()
        {

            return base.get_name();
        }

        //-----------------------------------------------------------------------------------------------------
        public override string get_full_desc()
        {
            return ("In the " + this.get_name() + " you see:" + "\n" + _inventory.list_items() + "\n");
        }

        //-----------------------------------------------------------------------------------------------------
        public Inventory get_inventory()
        {
            return _inventory;
        }

        private Inventory _inventory;
    }
}


