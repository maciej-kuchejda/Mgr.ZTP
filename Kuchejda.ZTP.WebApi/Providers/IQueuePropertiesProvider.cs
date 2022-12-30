using Azure.Messaging.ServiceBus;

namespace Kuchejda.ZTP.WebApi.Providers
{
    public interface IQueuePropertiesProvider
    {
        ServiceBusSender Sender { get; }
    }
}
