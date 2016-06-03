using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class Path : GameObj
    {

        public List<string> ids_item;
        public string name_item;
        public string desc_item;
        public Location destination_item;
        public bool bidirectional_item;

        //-----------------------------------------------------------------------------------------------------
        public Path(List<string> ids, string name, string desc, Location destination, bool bidirectional)
            : base(new List<string>(ids), name, desc)
        {
            _destination = destination;
            _bidirectional = bidirectional;

            ids_item = ids;
            name_item = name;
            desc_item = desc;
            destination_item = destination;
            bidirectional_item = bidirectional;
        }

        //-----------------------------------------------------------------------------------------------------
        public static explicit operator Path(Item _item)
        {
            Path _path = new Path(_item.ids_path, _item.name_path, _item.desc_path, _item.destination_path, _item.bidirectional_path);
            return _path;
        }

        //-----------------------------------------------------------------------------------------------------
        public void move(Player p)
        {

            if (_bidirectional)
            {

                _destination.add_path(this);

                Location wayBack = p.get_location();

                p.set_location(_destination);

                _destination = wayBack;

            }
            else
            {

                p.set_location(_destination);

            }
        }
        private Location _destination;
        private bool _bidirectional;
    }

}