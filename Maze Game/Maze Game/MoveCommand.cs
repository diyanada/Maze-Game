using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class MoveCommand : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public MoveCommand()
            : base(new List<string>(new List<string>() { "head", "move", "go" }))
        {
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {
            int length = (int)text.Count;
            string pathId = "";

            if (!(length > 1))
            {
                return "I don't know how to go there!";
            }

            else if (text[1 - 1] != "move" && text[1 - 1] != "head" && text[1 - 1] != "go")
            {
                return "I don't understand that.";
            }

            else if (text[1 - 1] == "move" || text[1 - 1] == "go")
            {

                if (!(text[2 - 1] == "into" || text[2 - 1] == "to" || text[2 - 1] == "down"))
                {
                    return "Down, into or to where?";
                }

                else
                {
                    pathId = text[3 - 1];
                }
            }

            else if (text[1 - 1] == "head")
            {

                if (!(text[2 - 1] == "north" || text[2 - 1] == "south" || text[2 - 1] == "east" || text[2 - 1] == "west"))
                {
                    return "I'll need a direction for that.";
                }

                else
                {
                    pathId = text[2 - 1];
                }
            }

            Item _item = (Item)player.locate(pathId);

            Path path = (Path)_item;

            if (path != null)
            {

                path.move(player);
                return player.get_name() + " went " + ((text[1 - 1] == "head") ? text[2 - 1] : "to the " + path.get_name()) + " and is now at " + player.get_location().get_name();

            }
            else
            {

                return "I can't find anywhere to go there";
            }

        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            string response = "";
            response += "[move] " + "Usage: move/go into/to/down <path>" + "";
            return response;
        }
    }
}


