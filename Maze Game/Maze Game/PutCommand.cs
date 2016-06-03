using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class PutCommand : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public PutCommand()
            : base(new List<string>(new List<string>() { "put", "drop" }))
        {
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {
            int length = (int)text.Count;
            string containerId = "";
            string itemId = "";

            if (length > 1)
            {

                if (length == 2 && text[1 - 1] == "drop")
                {

                    itemId = text[2 - 1];

                    containerId = player.get_location().first_id();
                }

                if (length >= 4 && text[1 - 1] == "put" && text[3 - 1] == "in")
                {

                    itemId = text[2 - 1];

                    containerId = text[4 - 1];
                }
            }

            IHaveInventory container = player.locate(containerId) as IHaveInventory;

            if (container != null)
            {
                return this.put_something_in(player, itemId, container);
            }
            else
            {
                return "Couldn't find the " + itemId;
            }

        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            string response = "";
            response += "[put ] " + "Usage: put <item> in <bag>" + "\n";
            response += "[drop] " + "Usage: drop <item>";
            return response;
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual string put_something_in(Player player, string itemId, IHaveInventory container)
        {

            GameObj item = player.locate(itemId);

            if (item != null)
            {
                Item itemToPut = player.get_inventory().take(itemId);
                container.get_inventory().put(itemToPut);
                return "I placed the " + itemId + " in " + container.get_name();
            }

            else
            {
                return "I don't have that item!";
            }
        }
    }
}


