using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class CommandControl
    {
        public async Task HandleCommand(string command, Message message, ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            switch (command)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Бот запущен!", cancellationToken: cancellationToken);
                    break;
                
                case "/help":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Список доступных команд:\n/start - начать работу с ботом\n/help - получить помощь\n/time - текущее время", cancellationToken: cancellationToken);
                    break;

                case "/time":
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Текущее время: {currentTime}", cancellationToken: cancellationToken);
                    break;

                default:
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Такой команды нет, используйте команду /help", cancellationToken: cancellationToken);
                    break;
            }
        }
    }
}