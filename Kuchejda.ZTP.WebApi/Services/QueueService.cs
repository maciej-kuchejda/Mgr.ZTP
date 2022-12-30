using Kuchejda.ZTP.WebApi.Clients;
using Kuchejda.ZTP.WebApi.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Kuchejda.ZTP.WebApi.Services
{
    public class QueueService : IQueueService
    {
        private readonly IServiceBusMessageBatchService _batchService;
        private readonly IQueueClient _queueClient;

        public QueueService(IServiceBusMessageBatchService batchService,
            IQueueClient queueClient)
        {
            _batchService = batchService;
            _queueClient = queueClient;
        }

        public async Task UploadAsync(IList<BusinessCard.Shared.Models.BusinessCard> businessCards)
        {
            var batch = await _batchService.Create(businessCards);

            await _queueClient.UploadAsync(batch);
        }
    }
}
