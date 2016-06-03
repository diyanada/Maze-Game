using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class Game
    {

        private Player _player;

        //-----------------------------------------------------------------------------------------------------
        public Game(string playerName, string playerDesc)
        {
            _player = new Player(playerName, playerDesc);

            //int player

            Item phone = new Item(new List<string>() { "phone", "iPhone" }, "phone", "A white iPhone 5");
            Item keys = new Item(new List<string>() { "keys" }, "keys", "My bording keys"); ;
            Item notebook = new Item(new List<string>() { "book", "textbook" }, "textbook", "An C# .NET note book of janaki"); ;

            Item cash = new Item(new List<string>() { "photo" }, "photo", "A photo of darshi");
            Item id_card = new Item(new List<string>() { "id", "license" }, "id", "A id card of University");

            Bag wallet = new Bag(new List<string>() { "wallet", "moneybag" }, "my wallet", "A leather wallet");
            Bag backpack = new Bag(new List<string>() { "backpack", "bag" }, "backpack", "A black packpack");

            Inventory backpack_inv = backpack.get_inventory();
            backpack_inv.put(keys);
            backpack_inv.put(notebook);
            

            Inventory wallet_inv = wallet.get_inventory();
            wallet_inv.put(cash);
            wallet_inv.put(id_card);
            

            Inventory player_inv = _player.get_inventory();
            player_inv.put(phone);
            player_inv.put(backpack);
            player_inv.put(wallet);

            //Main Gate
            Location gate = new Location(new List<string>() { "gate", "entrance" }, "Main Gate", "Main entrance of University");

            Path to_gate = new Path(new List<string>() { "gate", "entrance" }, "main gate", "Nice rood heads to main entrance of University", gate, false);

            //New building
            Location new_building = new Location(new List<string>() { "new_building" }, "New building", "New building of University");

            Item cash_note = new Item(new List<string>() { "cash", "money", "notes" }, "100 rupee note", "A 100 rupee note feld on floor");

            Inventory new_building_inv = new_building.get_inventory();
            new_building_inv.put(cash_note);

            Path to_new_building = new Path(new List<string>() { "door", "n" }, "door to New building", "Nice rood heads to new building of University", new_building, false);

            //old building
            Location old_building = new Location(new List<string>() { "old_building" }, "old building", "old building of University");

            Item pc = new Item(new List<string>() { "pc", "computer" }, "Small Computer", "The darshi\'s mini laptop");

            Inventory old_buildingt_inv = old_building.get_inventory();
            old_buildingt_inv.put(pc);

            Path to_old_building = new Path(new List<string>() { "entrance", "o" }, "door to old building", "Nice rood heads to old building of University", old_building, false);
            Path to_old_building_fm_nb = new Path(new List<string>() { "door", "entrance" }, "door to old building", "you exit from back door of new build and enter to old building using font door of a old building", old_building, false);

            //old building 1st floor

            Location old_building_1 = new Location(new List<string>() { "upstairs"}, "old building 1st floor", "old building 1st floor of University");

            Item notice = new Item(new List<string>() { "notice", "n", "notice_board"}, "notice board", "you have A+ for C# .net programming");

            Inventory old_building_1_inv = old_building_1.get_inventory();
            old_building_1_inv.put(notice);

            Path to_old_building_1 = new Path(new List<string>() { "stairs", "s" }, "upstairs", "you climb a stairs and reach to 1st floor of old building in old bulidng", old_building_1, false);

            //sir room

            Location sir_room = new Location(new List<string>() { "room" }, "Mr. P. Urthiran\'s room", "oh! sir is not in the room");

            Item gem = new Item(new List<string>() { "gem" }, "a red gem", "A bright red ruby the size of your fist!");

            Bag bag = new Bag(new List<string>() { "bag" }, "bag", "a leather bag");

            Inventory bag_inv = bag.get_inventory();
            bag_inv.put(gem);

            Inventory sir_room_inv = sir_room.get_inventory();
            sir_room_inv.put(bag);

            Path to_sir_room = new Path(new List<string>() { "door", "entrance" }, "Mr. P. Urthiran\'s room", "the door is not locked so you are in side ", sir_room, true);

            //Path details

            gate.add_path(to_new_building);
            gate.add_path(to_old_building);

            new_building.add_path(to_old_building_fm_nb);
            new_building.add_path(to_gate);

            old_building.add_path(to_old_building_1);
            old_building.add_path(to_gate);

            old_building_1.add_path(to_sir_room);

           // closet.add_path(to_west);
           // closet.add_path(to_east);

           // garden.add_path(to_south);

            _player.set_location(gate);
        }

        //-----------------------------------------------------------------------------------------------------
        public Player get_player()
        {
            return _player;
        }
    }

}


