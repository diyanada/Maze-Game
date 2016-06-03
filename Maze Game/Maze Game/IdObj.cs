using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class IdObj
    {

        private List<string> _ids = new List<string>();

        //-----------------------------------------------------------------------------------------------------
        public IdObj(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {

                this.add_id(ids[i]);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public bool are_you_a(string id)
        {

            if (_ids.Contains(id))
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public string first_id()
        {
            if (!(_ids.Count == 0))
            {
                return _ids[0];
            }
            else
            {
                return "";
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public void add_id(string id)
        {
            _ids.Add(id.ToLower());
        }

    }

}

