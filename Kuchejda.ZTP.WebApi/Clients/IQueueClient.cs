using Azure.Messaging.ServiceBus;

namespace Kuchejda.ZTP.WebApi.Clients
{
    public interface IQueueClient
    {
        Task UploadAsync(ServiceBusMessageBatch batchMessages);
    }
}
