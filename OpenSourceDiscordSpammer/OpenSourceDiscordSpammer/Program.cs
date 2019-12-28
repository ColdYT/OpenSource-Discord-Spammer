using System;
using System.IO;
using System.Threading;

namespace OpenSourceDiscordSpammer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = "OpenSource Discord Spammer - By Xaxlii";
            Console.WriteLine("Loading tokens...");
            try
            {
                Commands.LoadClients(File.ReadAllLines("tokens.txt"));
            } catch (FileNotFoundException)
            {
                Console.WriteLine("Couldn't find the tokens.txt file");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }


            CommandHandler.ShowCommands();
            Console.WriteLine();

            while (true)
            {
                Console.Write("Action: ");
                CommandHandler.Commandhandler(int.Parse(Console.ReadLine()));
            }
        }
    }
}
