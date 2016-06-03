using System.Collections.Generic;

namespace Maze_Game
{
    //-----------------------------------------------------------------------------------------------------
    public class CommandProcessor : Command
    {

        //-----------------------------------------------------------------------------------------------------
        public CommandProcessor()
            : base(new List<string>())
        {
            LookCommand cmdLook = new LookCommand();
            MoveCommand cmdMove = new MoveCommand();
            QuitCommand cmdQuit = new QuitCommand();
            TakeCommand cmdTake = new TakeCommand();
            PutCommand cmdPut = new PutCommand();

            _commands.Add(cmdLook);
            _commands.Add(cmdMove);
            _commands.Add(cmdQuit);
            _commands.Add(cmdTake);
            _commands.Add(cmdPut);
            _commands.Add(this);
        }

        //-----------------------------------------------------------------------------------------------------
        public void Dispose()
        {
            _commands.Clear();
        }

        //-----------------------------------------------------------------------------------------------------
        public override string execute(Player player, List<string> text)
        {

            string cmd_id = text[1 - 1];

            if (cmd_id == "help" || cmd_id == "?")
            {
                return this.help();
            }
            else if (text.Count > 1 && (text[2 - 1].Equals("help") || text[2 - 1].Equals("?")))
            {

                return this.help(cmd_id);

            }

            else
            {
                string response = "";

                _commands.ForEach(delegate(Command cmd)
                {
                    if (cmd.are_you_a(cmd_id)) response = cmd.execute(player, text);
                });

                if (response == "") response = "I don't understand that";

                return response;

            }

        }

        //-----------------------------------------------------------------------------------------------------
        public override string description()
        {
            return "[help] Usage: shows this list";
        }

        private List<Command> _commands = new List<Command>();

        //-----------------------------------------------------------------------------------------------------
        private string help()
        {
            string response = "";

            _commands.ForEach(delegate(Command cmd)
            {
                response += cmd.description() + "\n";
            });
            return response;
        }

        //-----------------------------------------------------------------------------------------------------
        private string help(string cmd_id)
        {
            string response = "";

            _commands.ForEach(delegate(Command cmd)
            {
                if (cmd.are_you_a(cmd_id)) response = cmd.description();
            });

            if (response == "") response = "Can't provide help for a command that doesn't exist!";

            return response;

        }

    }

}

