using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TestBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("717435055:AAFc_W3cyGcoo90k63STovpMkzRDRV4n38Q");
        static void Main(string[] args)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text) return;
            Console.WriteLine(e.Message.Text);
            switch (e.Message.Text.ToLower())
            {
                case "/how are you ?":
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Fine, thank you, and you ?");
                    break;
                case "/hi":
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello " + e.Message.Chat.Username);
                    break;
                case "/good morning":
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Good Morning " + e.Message.Chat.Username);
                    break;
                default:
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Usage: 
                        /How are you ?
                        /Good Morning 
                    ");
                    break;
            }
        }
    }
}
