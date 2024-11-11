using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.comands;

public class HelpCommand : ICommand
{
    public async Task Execute(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        string helpText = "Список доступных команд:\n/start - начать работу с ботом\n/help - получить помощь";
        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: helpText, cancellationToken: cancellationToken);
    }
}