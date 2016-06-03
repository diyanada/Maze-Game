using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class TakeCommand : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public TakeCommand()
            : base(new List<string>(new List<string>() { "take", "pickup" }))
        {
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {
            int length = (int)text.Count;
            string containerId = "";
            string itemId = "item";

            if (length > 1)
            {

                if (length == 2 && (text[1 - 1] == "take" || text[1 - 1] == "pickup"))
                {

                    itemId = text[2 - 1];

                    containerId = player.get_location().first_id();
                }

                if (length >= 4 && text[1 - 1] == "take" && text[3 - 1] == "from")
                {

                    itemId = text[2 - 1];

                    containerId = text[4 - 1];
                }
            }

            IHaveInventory container = player.locate(containerId) as IHaveInventory;

            if (container != null)
            {
                return this.take_something_in(player, itemId, container);
            }
            else
            {
                return "I couldn't find the " + itemId;
            }

        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            string response = "";
            response += "[take] " + "Usage: take <item>" + "\n";
            response += "       " + "       pickup <item> from <bag>";
            response += "       " + "       take <item> from inventory" + "\n";
            response += "       " + "       take <item> from <bag>";
            return response;
        }

        //-----------------------------------------------------------------------------------------------------
        public virtual string take_something_in(Player player, string itemId, IHaveInventory container)
        {

            GameObj item = container.locate(itemId);

            Path pathTest = container.locate(itemId) as Path;

            if (item != null && pathTest == null)
            {
                Item itemToTake = container.get_inventory().take(itemId);
                player.get_inventory().put(itemToTake);
                return "Took the " + itemId;
            }

            else
            {
                return "I couldn't find/take the " + itemId + " inside the " + container.get_name();
            }
        }
    }

}

