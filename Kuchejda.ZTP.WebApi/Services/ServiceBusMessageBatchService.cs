using Azure.Messaging.ServiceBus;
using Kuchejda.ZTP.WebApi.Providers;

namespace Kuchejda.ZTP.WebApi.Services
{
    public class ServiceBusMessageBatchService : IServiceBusMessageBatchService
    {
        private readonly IQueuePropertiesProvider _provider;
        private readonly IJsonProvider _jsonProvider;

        public ServiceBusMessageBatchService(IQueuePropertiesProvider provider, IJsonProvider jsonProvider)
        {
            _provider = provider;
            _jsonProvider = jsonProvider;
        }

        public async Task<ServiceBusMessageBatch> Create<TBody>(IEnumerable<TBody> entities) where TBody : class
        {
            var batch = await _provider.Sender.CreateMessageBatchAsync();

            foreach (var item in entities)
            {
                var jsonBody = _jsonProvider.Serialize(item);

                batch.TryAddMessage(new ServiceBusMessage(jsonBody));
            }

            return batch;
        }
    }
}
