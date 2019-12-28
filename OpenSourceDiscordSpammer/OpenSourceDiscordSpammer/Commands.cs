using System;
using Discord;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSourceDiscordSpammer
{
    public static class Commands
    {
        private static List<DiscordClient> Clients { get; set; }

        public static void LoadClients(string[] tokens)
        {
            Clients = new List<DiscordClient>();

            foreach (var Token in tokens)
            {
                try
                {
                    DiscordClient Client = new DiscordClient(Token);
                    Clients.Add(Client);
                    Console.WriteLine($"Valid connection to {Token} {Client.User.Username}");
                } catch (DiscordHttpException)
                {

                }
            }
        }


        public static void Joiner(string InviteCode)
        {
            Parallel.ForEach(Clients, Client =>
            {
                try
                {
                    Client.JoinGuild(InviteCode);
                }catch (DiscordHttpException)
                {
                    Console.WriteLine($"Error from {Client.User}");
                }
            });
        }

        public static void Flooder(ulong ChannelId, string Message)
        {
            Parallel.ForEach(Clients, new ParallelOptions { MaxDegreeOfParallelism = 3 }, Client =>
            {
                while (true)
                {
                    try
                    {
                        Client.SendMessage(ChannelId, Message, false, null);
                    }
                    catch (RateLimitException)
                    {
                        Console.WriteLine($"Error from {Client.User}");
                    }
                    catch (DiscordHttpException)
                    {
                        Console.WriteLine($"Error from {Client.User}");
                    }
                }
            });
        }



        public static void DmFlooder(ulong UserId, string Message)
        {
            Parallel.ForEach(Clients, new ParallelOptions { MaxDegreeOfParallelism = 3 }, Client =>
            {
                while (true)
                {
                    try
                    {
                        var DmChannel = Client.CreateDM(UserId);
                        DmChannel.SendMessage(Message, false, null);
                    }
                    catch (RateLimitException)
                    {
                        Console.WriteLine($"Error from {Client.User}");
                    }
                    catch (DiscordHttpException)
                    {
                        Console.WriteLine($"Error from {Client.User}");
                    }
                }
            });
        }



        public static void FriendRequester(string Username, uint Discriminator)
        {
            Parallel.ForEach(Clients, Client =>
            {
                try
                {
                    Client.SendFriendRequest(Username, Discriminator);
                }
                catch (DiscordHttpException)
                {
                    Console.WriteLine($"Error from {Client.User}");
                }
            });
        }


        public static void Leaver(ulong ServerId)
        {
            Parallel.ForEach(Clients, Client =>
            {
                try
                {
                    Client.LeaveGuild(ServerId);
                }
                catch (DiscordHttpException)
                {
                    Console.WriteLine($"Error from {Client.User}");
                }
            });
        }
    }
}
