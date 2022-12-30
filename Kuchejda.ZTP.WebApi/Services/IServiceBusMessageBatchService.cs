using Azure.Messaging.ServiceBus;

namespace Kuchejda.ZTP.WebApi.Services
{
    public interface IServiceBusMessageBatchService
    {
        Task<ServiceBusMessageBatch> Create<TBody>(IEnumerable<TBody> entities) where TBody : class;
    }
}
