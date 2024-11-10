using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.comands;

public class StartCommand : ICommand
{
    public async Task Execute(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Бот готов!", cancellationToken: cancellationToken);
    }
}