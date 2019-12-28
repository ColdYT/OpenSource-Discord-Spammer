using System;

namespace OpenSourceDiscordSpammer
{
    public static class CommandHandler
    {
        public static void ShowCommands()
        {
            Console.WriteLine(@"Joiner - 1
Flooder - 2
DmFlooder - 3
Friend Requster - 4
Leaver - 5");
        }


        public static void Commandhandler(int type)
        {
            switch(type)
            {
                case 1:
                    Console.Write("InviteCode: ");
                    string InviteCode = Console.ReadLine();
                    Commands.Joiner(InviteCode);
                    Console.Clear();
                    ShowCommands();
                    break;
                case 2:
                    Console.Write("ChannelId: ");
                    ulong ChannelId = ulong.Parse(Console.ReadLine());
                    Console.Write("Message: ");
                    string Message = Console.ReadLine();
                    Commands.Flooder(ChannelId, Message);
                    Console.Clear();
                    ShowCommands();
                    break;
                case 3:
                    Console.Write("UserId: ");
                    ulong UserId = ulong.Parse(Console.ReadLine());
                    Console.Write("Message: ");
                    string message = Console.ReadLine();
                    Commands.DmFlooder(UserId, message);
                    Console.Clear();
                    ShowCommands();
                    break;
                case 4:
                    Console.Write("Username: ");
                    string Username = Console.ReadLine();
                    Console.Write("Discriminator: ");
                    uint Discriminator = uint.Parse(Console.ReadLine());
                    Commands.FriendRequester(Username, Discriminator);
                    Console.Clear();
                    ShowCommands();
                    break;
                case 5:
                    Console.Write("ServerId: ");
                    ulong ServerId = ulong.Parse(Console.ReadLine());
                    Commands.Leaver(ServerId);
                    Console.Clear();
                    ShowCommands();
                    break;
            }
        }
    }
}
