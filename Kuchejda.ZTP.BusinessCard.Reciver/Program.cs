
using Azure.Messaging.ServiceBus;
using Kuchejda.ZTP.BusinessCard.Reciver.Configuration;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();

var config = new QueueConfiguration();
configuration.GetSection("QueueConfiguration").Bind(config);

ServiceBusClient client = new ServiceBusClient(config.ConnectionString);
var  processor = client.CreateProcessor(config.QueueName, new ServiceBusProcessorOptions());

processor.ProcessMessageAsync += MessageHandler;

processor.ProcessErrorAsync += ErrorHandler;

await processor.StartProcessingAsync();

Console.WriteLine("Wait for a minute and then press any key to end the processing");
Console.ReadKey();

// stop processing 
Console.WriteLine("\nStopping the receiver...");
await processor.StopProcessingAsync();
Console.WriteLine("Stopped receiving messages");

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");

    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}
