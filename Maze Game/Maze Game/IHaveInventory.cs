
namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public interface IHaveInventory
    {

        GameObj locate(string id);
        Inventory get_inventory();
        string get_name();
    }

}


