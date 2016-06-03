using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class LookCommand : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public LookCommand()
            : base(new List<string>(new List<string>() { "look", "examine" }))
        {
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {
            int length = (int)text.Count;

            string containerId = "";
            string itemId = "";
            if (length > 2)
            {
                itemId = text[3 - 1];
                if (itemId == "inv") itemId = "inventory";
            }

            if (text[1 - 1] == "look" && length == 1)
            {
                text.Insert((2 - 1), "here");
            }

            if (!(length > 0))
            {
                return "I don't know how to look like that!";
            }
                            
            else if (text[1 - 1] != "look")
            {
                return "I don't understand that.";
            }

            else if (text[2 - 1] == "here" || text[2 - 1] == "around")
            {
                return player.get_location().get_full_description();
            }

            else if (text[2 - 1] != "at" && text[2 - 1] != "in")
            {
                return "What should I look at?";
            }

            else if (length == 5 && text[4 - 1] != "in")
            {
                return "What should I look in?";
            }

            else if (length == 3)
            {
                containerId = "inventory";
            }

            else if (length == 5)
            {
                containerId = text[5 - 1];
            }

            IHaveInventory container = player.locate(containerId) as IHaveInventory;

            if (container != null)
            {
                return this.look_at_in(player, itemId, container);
            }
            else
            {
                return "Couldn't find the " + containerId;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            string response = "";
            response += "[look] " + "Usage: look" + "\n";
            response += "       " + "       look here/around" + "\n";
            response += "       " + "       look at/in inventory" + "\n";
            response += "       " + "       look at/in <itemA> in <itemB>";
            return response;
        }

        //-----------------------------------------------------------------------------------------------------
        private string look_at_in(Player player, string itemId, IHaveInventory container)
        {

            GameObj item = container.locate(itemId);
            if (item != null)
            {
                return item.get_full_desc();
            }
            else
            {
                return "Couldn't find the " + itemId;
            }
        }
    }

}


