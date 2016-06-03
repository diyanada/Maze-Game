using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class GameObj : IdObj
    {

        private string _description;
        private string _name;

        //-----------------------------------------------------------------------------------------------------
        public GameObj(List<string> ids, string name, string desc)
            : base(new List<string>(ids))
        {

            _name = name;
            _description = desc;

        }

        //-----------------------------------------------------------------------------------------------------
        public virtual string get_name()
        {
            return _name;
        }

        //-----------------------------------------------------------------------------------------------------
        public string get_short_desc()
        {
            return _name + " (" + this.first_id() + ")";
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual string get_full_desc()
        {
            return _description;
        }
    }
}


