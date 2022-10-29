using Kuchejda.ZTP.BusinessCard.Producer.Clients;
using Kuchejda.ZTP.BusinessCard.Producer.Configuration;
using Kuchejda.ZTP.BusinessCard.Shared.Models;
using Microsoft.Extensions.Options;

namespace Kuchejda.ZTP.BusinessCard.Producer.Services
{
    public class BusinessCardProvider : IBusinessCardProvider
    {
        private readonly IBusinessCardClient _businessCardClient;
        private readonly BusinessCardConfiguration _configuration;

        public BusinessCardProvider(IBusinessCardClient businessCardClient,
            IOptions<BusinessCardConfiguration> configuration)
        {
            _businessCardClient = businessCardClient;
            _configuration = configuration.Value;
        }

        public async Task UploadAsync(IEnumerable<BusinessCardDTO> models)
        {
            await _businessCardClient.PostAsync(_configuration.Host, models);
        }
    }
}
