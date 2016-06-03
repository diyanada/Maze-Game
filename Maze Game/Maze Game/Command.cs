using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public abstract class Command : IdObj
    {

        //-----------------------------------------------------------------------------------------------------
        public Command(List<string> ids)
            : base(new List<string>(ids))
        {
        }

        public abstract string execute(Player player, List<string> text);

        public abstract string description();
    }

}

