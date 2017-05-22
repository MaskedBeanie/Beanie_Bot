using System;
using System.Linq;
using Discord;
using Discord.Commands;

namespace Beanie_Bot_9000
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Program().Initialize();

        }

        private DiscordClient discordClient;

        public void Initialize()
        {
            var discordToken = "MjcyMjAwNjE0MDg2MzExOTM2.C_59DQ.54wr7dHDOmdXinRuwz47gj_GjQ4";


            discordClient = new DiscordClient(x =>
            {
                x.AppName = "Beanie Bot";
                x.AppUrl = "http://maskedbeanie-services.weebly.com";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = LogHandler;

            });


            discordClient.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.HelpMode = HelpMode.Public;
                x.AllowMentionPrefix = true;
            });

            discordClient.ExecuteAndWait(async () =>
            {
                await discordClient.Connect(discordToken, TokenType.Bot);
            });


        }




        // Chat Responses



        public void ConstituteCommands()
        {
            var eService = discordClient.GetService<CommandService>();

            var currentVersion = 1.70;
            string latestUpdate = ("`Latest Update: " + currentVersion + " | Users can now use the !apply shortcut to the staff application form.`");

            string[] cussWords = new string[] { "@ss", "ass", "fuck", "shit", "pussy", "pu$$y", "dick", "d!ck", "dlck", "vagina", "v@gina", "bitch", "b!tch", "cunt", "nigger", "nigga", "nigg@", "bastard", "faggot", "kys", "prick" };

            // bool takingRequests = true;

            eService.CreateCommand("!update")
                .Description("Displays details of the latest version of Beanie Bot.")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage(latestUpdate);
                });
        }

        /*
        private static async void DiscordClient_MessageReceived(object sender, MessageEventArgs e)
        {
            // Settings
            

            // 

            


            // Hunter Sucks :P

            if (takingRequests == false)
            {
                Console.WriteLine("Error: [Taking Requests] disabled.");
            }
                

            // !update

            else if (lowerCased == "!update")
            {
                await e.Channel.SendMessage(latestUpdate);
            }

            // Cuss Filter

            else if (cussWords.Any(lowerCased.Contains))
            {
                await e.Message.Delete();
                Console.WriteLine(e.User.Name + " has been censored! (Message: " + e.Message.Text + " )");
            }


            // !report

            else if (lowerCased == "!report")
            {
                await e.Channel.SendMessage(e.User.Mention + ", report an abuse via the following form: https://goo.gl/forms/4KXhiv6VZAgv8ZIF3");
            }

            // !apply

            else if (lowerCased == "!apply")
            {
                await e.Channel.SendMessage(e.User.Mention + ", you can apply for staff via the following form: https://goo.gl/forms/Tpwd8nW1rCEhxC612");
            }

            // !alert

            else if (lowerCased == "!alerton")
            {
                foreach (Role role in e.Server.Roles)
                {
                    if (role.Name == "👑 | Founder")
                    {
                        if (e.User.HasRole(role))
                        {
                            await e.Channel.SendMessage("!! ALERT MODE ENGAGED !!");
                            takingRequests = false;
                        }

                    }
                }
            }

        }

        
        private static void AssignDefaultRank(object sender, UserEventArgs e)
        {
            foreach (Role role in e.Server.Roles)
            {
                if (role.Name == "🙂 | Member")
                {
                    e.User.AddRoles(role);
                }
            }
        }
        

        */


        public static void LogHandler(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] {e.Message}");
        }

    }
}
