using Azure.Core;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Kuchejda.ZTP.WebApi.Configuration;
using Kuchejda.ZTP.WebApi.Providers;
using Microsoft.Extensions.Options;

namespace Kuchejda.ZTP.WebApi.Clients
{
    public class QueueClient : IQueueClient, IQueuePropertiesProvider
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;
        private readonly QueueConfiguration _configuration;

        public QueueClient(IOptions<QueueConfiguration> options)
        {
            _configuration = options.Value;

            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };

            _client = new ServiceBusClient(_configuration.ConnectionString);

            _sender = _client.CreateSender(_configuration.QueueName);
        }

        public ServiceBusSender Sender => _sender;

        public async Task UploadAsync(ServiceBusMessageBatch batchMessages) 
        {
            await _sender.SendMessagesAsync(batchMessages);

            await _client.DisposeAsync();
            await _sender.DisposeAsync();
            batchMessages.Dispose();
        }
    }
}
