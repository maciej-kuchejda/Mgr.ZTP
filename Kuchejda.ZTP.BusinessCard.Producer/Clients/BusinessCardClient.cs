using Kuchejda.ZTP.BusinessCard.Producer.Configuration;
using Kuchejda.ZTP.BusinessCard.Producer.Exceptions;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Kuchejda.ZTP.BusinessCard.Producer.Clients
{
    public class BusinessCardClient : IBusinessCardClient
    {
        private readonly BusinessCardConfiguration _configuration;

        public BusinessCardClient(IOptions<BusinessCardConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public async Task PostAsync<TBody>(string uri, TBody body) where TBody : class
        {
            var client = new RestClient(_configuration.Host);

            var restRequest = new RestRequest(uri, Method.Post);
            if (body != null)
                restRequest.AddJsonBody(body);

            var response = await client.ExecuteAsync(restRequest);

            if (!response.IsSuccessful)
                throw new ApiException($"Api exception while executing post method: {response.StatusCode} {response.Content}");
        }
    }
}
