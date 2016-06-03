using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Maze_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
           

            Console.WriteLine(".NET Programming Project");
            Console.WriteLine("2nd Year – I Semester");
            Console.WriteLine("B. Tech - Software Technology");
            Console.WriteLine("B. Tech – Multimedia and Web Technology");
            Console.WriteLine("2014-15 Batch");
            Console.WriteLine("University of Vocational Technology");
            Console.Write("\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("\n");

            Console.WriteLine("Game Objective :- Find a red gem from some where in the university");
            Console.WriteLine("if you need to know about the commands you can type \"help\" or \"?\" ");

            Console.Write("\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("\n");

            string playerName;
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();

            Game _game = new Game(playerName, "Description");

            string input;
            List<string> subStrings = new List<string>();
            string word = "";

            char[] inputar;

            CommandProcessor cmd = new CommandProcessor();
            while (true)
            {

                Console.Write("\n");
                Console.Write("Command -> ");

                input = Console.ReadLine();
                input += ' ';
                inputar = input.ToCharArray();

                int wordStart = 0;

                for (int i = 0; i < inputar.Length; i++)
                {

                    if (inputar[i] == ' ')
                    {

                        for (int j = wordStart; j < i; j++)
                        {
                            word += inputar[j];
                        }

                        subStrings.Add(word);

                        word = "";

                        wordStart = i + 1;
                    }
                }

                if (inputar[0] != ' ')
                {

                    string response = cmd.execute(_game.get_player(), subStrings);
                    Console.Write(response);

                    if (response == "Quitting")
                        break;

                    input = null;

                    subStrings.Clear();
                }

            }
        }
    }
}


