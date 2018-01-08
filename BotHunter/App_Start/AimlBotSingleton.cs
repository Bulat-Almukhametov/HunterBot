using AIMLbot;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Xml;

namespace BotHunter.App_Start
{
    public static class AimlBotSingleton
    {
        private static MemoryCache _Bots = new MemoryCache("Bots");
        private static MemoryCache _Users = new MemoryCache("Users");
        private static MemoryCache _Dialogs = new MemoryCache("Dialogs");
        private static Models.DataRepository _Repository = new Models.DataRepository();

        static Bot GetBot(ChannelAccount account)
        {
            //if (_Bots[account.Id] == null)
            //{
                var aimlBot = new Bot();
                var path = HttpContext.Current.Server.MapPath("~/");
                aimlBot.loadCustomTagHandlers(path + @"bin/AimlTags.dll");
                aimlBot.UpdatedConfigDirectory = path + @"AimlBotXmls/config";
                aimlBot.UpdatedAimlDirectory = path + @"AimlBotXmls/aiml";
                aimlBot.loadSettings();
                aimlBot.isAcceptingUserInput = false;
                aimlBot.loadAIMLFromFiles();
                aimlBot.isAcceptingUserInput = true;

                var doc = new XmlDocument();
                doc.LoadXml(GetAimlFromDb());
                aimlBot.loadAIMLFromXML(doc, "FromDb");


                var policy = new CacheItemPolicy
                {
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                };
            //    _Bots.Add(account.Id, aimlBot, policy);
            //}

            //return (Bot)_Bots[account.Id];
            return aimlBot;
        }

        private static string GetAimlFromDb()
        {
            string dialogs = null;
            //dialogs = _Dialogs["DbDialogs"] as string;

            //if (dialogs == null)
            //{
                dialogs = "<aiml>" + String.Join(Environment.NewLine, _Repository.Dialogs.Select(d => d.Aiml)) + "</aiml>";
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(3)
                };
                //_Dialogs.Set("DbDialogs", dialogs, policy);
            //}
            return dialogs;
        }

        static AimlBotSingleton()
        {
            
        }

      

        public static AIMLbot.User GetUser(ChannelAccount account)
        {
            //if (_Users[account.Id] == null)
            //{
            var user = new User(account.Id, GetBot(account));
            user.Predicates.updateSetting("name", account.Name);

                var policy = new CacheItemPolicy
                {
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                };
            //    _Users.Add(account.Id, user, policy);
            //}

            //return (User)_Users[account.Id];
            return user;
        }

        public static string Chat(ChannelAccount account, string text)
        {
            var bot = GetBot(account);
            Request r = new Request(text, GetUser(account), bot);
            Result res = bot.Chat(r);
            

            return res.Output;
        }
    }
}