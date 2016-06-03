using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class Item : GameObj
    {

        public List<string> ids_path;
        public string name_path;
        public string desc_path;
        public Location destination_path;
        public bool bidirectional_path;

        //-----------------------------------------------------------------------------------------------------
        public Item(List<string> ids, string name, string desc)
            : base(new List<string>(ids), name, desc)
        {
            ids_path = ids;
            name_path = name;
            desc_path = desc;
        }

        //-----------------------------------------------------------------------------------------------------
        public Item(List<string> ids, string name, string desc, Location destination, bool bidirectional)
            : base(new List<string>(ids), name, desc)
        {
            ids_path = ids;
            name_path = name;
            desc_path = desc;
            destination_path = destination;
            bidirectional_path = bidirectional;
        }

        //-----------------------------------------------------------------------------------------------------
        public static explicit operator Item(Path _path)
        {
            Item _item = new Item(_path.ids_item, _path.name_item, _path.desc_item, _path.destination_item, _path.bidirectional_item);
            return _item;
        }

    }


}