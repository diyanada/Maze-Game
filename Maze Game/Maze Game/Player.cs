using System.Collections.Generic;

namespace Maze_Game
{
    public class Player : GameObj, IHaveInventory
    {

        private Inventory _inventory;
        private Location _location;

        //-----------------------------------------------------------------------------------------------------
        public Player(string name, string desc)
            : base(new List<string>() { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location(new List<string>() { "nowhere" }, "Nowhere", "The emptiness of space");
        }

        //-----------------------------------------------------------------------------------------------------
        public void Dispose()
        {
            if (_inventory != null)
                _inventory.Dispose();
            if (this != null)
                this.Dispose();
        }

        //-----------------------------------------------------------------------------------------------------
        public GameObj locate(string id)
        {

            if (are_you_a(id))
            {
                return this;

            }
            else if (_inventory.has_item(id))
            {
                return (GameObj)_inventory.fetch(id);
            }

            else if (_location.locate(id) != null)
            {
                return _location.locate(id);
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
            return _inventory.list_items();
        }

        //-----------------------------------------------------------------------------------------------------
        public Inventory get_inventory()
        {
            return _inventory;
        }
        //-----------------------------------------------------------------------------------------------------
        public Location get_location()
        {
            return _location;
        }
        //-----------------------------------------------------------------------------------------------------
        public void set_location(Location loc)
        {
            _location = loc;
        }
    }

}