using System;
using System.Collections.Generic;

namespace Maze_Game
{
    public class Location : GameObj, IHaveInventory
    {

        //-----------------------------------------------------------------------------------------------------
        public Location(List<string> ids, string name, string desc)
            : base(new List<string>(ids), name, desc)
        {
            _inventory = new Inventory();
            _paths = new Inventory();
        }

        //-----------------------------------------------------------------------------------------------------
        public void Dispose()
        {
            if (_inventory != null)
                _inventory.Dispose();
            Dispose();
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual GameObj locate(string id)
        {

            if (are_you_a(id))
            {
                return this;

            }

            else if (_inventory.has_item(id))
            {
                return (GameObj)_inventory.fetch(id);
            }

            else if (_paths.has_item(id))
            {
                return (GameObj)_paths.fetch(id);
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
        public Inventory get_inventory()
        {
            return _inventory;
        }

        //-----------------------------------------------------------------------------------------------------
        public void add_path(Path path)
        {

            if (!_paths.has_item(path.first_id()))
            {

                _paths.put((Item)path);

            }
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual string get_full_description()
        {
            string desc = "";
            desc += "This is " + this.get_name() + " - " + base.get_full_desc() + "\n" + "\n";
            desc += "Items: " + "\n" + "-----" + "\n" + _inventory.list_items() + "\n";
            desc += "Paths: " + "\n" + "-----" + "\n" + _paths.list_items() + "\n";
            return desc;
        }

        private Inventory _inventory;
        private Inventory _paths;
    }

}


