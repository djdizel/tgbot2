using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.comands;

public class CommandControl
{
    private readonly Dictionary<string, ICommand> _commands;

    public CommandControl()
    {
        _commands = new Dictionary<string, ICommand>
        {
            { "/start", new StartCommand() },
            { "/help", new HelpCommand() }
        };
    }

    public async Task HandleCommand(string commandText, ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        if (_commands.TryGetValue(commandText, out ICommand command))
        {
            await command.Execute(botClient, message, cancellationToken);
        }
        else
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Неизвестная команда. Используйте /help.", cancellationToken: cancellationToken);
        }
    }
}