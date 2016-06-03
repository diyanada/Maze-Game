using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class QuitCommand : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public QuitCommand()
            : base(new List<string>(new List<string>() { "quit", "exit" }))
        {
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {
            if (text[1 - 1] == "quit" || text[1 - 1] == "exit")
            {
                return "Quitting";
            }
            else
            {
                return "I don't understand that";
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            return "[quit] Usage: quits the program";
        }
    }

}

