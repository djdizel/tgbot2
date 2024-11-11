using System;
using System.Threading.Tasks;
using TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;

namespace TelegramBot
{
class Program
{
    static string BotToken = "7829510317:AAGOiFPrk68q8vYpkFUS5NxuM7RM02N-YNA";
    static ITelegramBotClient botClient;

    static async Task Main(string[] args)
    {
        botClient = new TelegramBotClient(BotToken);
        var me = await botClient.GetMeAsync();
        Console.WriteLine(me.FirstName);
        
        var cancellationTokenSource = new CancellationTokenSource();
        
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() 
        };
        
        botClient.StartReceiving(HandleUpdateAsync, HandelPollingErrorAsync, 
        receiverOptions,cancellationToken: cancellationTokenSource.Token);
            
        Console.WriteLine("Bot is up and running. Press Enter to exit.");
        Console.ReadLine();
        cancellationTokenSource.Cancel();
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient,Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message && update.Message?.Text != null)
        {
            var commandHandler = new CommandControl();
            string messageText = update.Message.Text;

            await commandHandler.HandleCommand(messageText.Split(' ')[0],botClient, update.Message, cancellationToken);
        }
    }

    static Task HandelPollingErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }

    
}
}