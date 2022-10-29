using Kuchejda.ZTP.WebApi.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Kuchejda.ZTP.WebApi.Services
{
    public class QueueService : IQueueService
    {
        private readonly QueueConfiguration _configuration;
        private readonly RestClient _restClient;

        public QueueService(IOptions<QueueConfiguration> configuration)
        {
            _configuration = configuration.Value;
            _restClient = new RestClient(_configuration.Host);
        }

        public void Upload(IList<BusinessCard.Shared.Models.BusinessCard> businessCards)
        {
            throw new NotImplementedException();
        }
    }
}
