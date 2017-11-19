using AIMLbot;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.App_Start
{
    public static class AimlBotSingleton
    {
        private static Bot _AimlBot;
        private static Dictionary<String, User> _Users;
        static AimlBotSingleton()
        {
            _AimlBot = new Bot();
            var path = HttpContext.Current.Server.MapPath("~/bin");
            _AimlBot.UpdatedConfigDirectory = path + @"/config";
            _AimlBot.UpdatedAimlDirectory = path + @"/aiml";
            _AimlBot.loadSettings();
            _AimlBot.isAcceptingUserInput = false;
            _AimlBot.loadAIMLFromFiles();
            _AimlBot.isAcceptingUserInput = true;

            _Users = new Dictionary<string, User>();
        }

        public static Bot Bot
        {
            get
            {
                return _AimlBot;
            }
        }

        public static User GetUser(ChannelAccount account)
        {
            if (!_Users.ContainsKey(account.Id))
            {
                var user = new User(account.Id, _AimlBot);
                user.Predicates.updateSetting("name", account.Name);
                _Users.Add(account.Id, user);
            }
            return _Users[account.Id];
        }

        public static string Chat(ChannelAccount account, string text)
        {
            Request r = new Request(text, GetUser(account), _AimlBot);
            Result res = _AimlBot.Chat(r);
            

            return res.Output;
        }
    }
}