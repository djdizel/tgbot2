using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.comands;

public interface ICommand
{
    Task Execute(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
}