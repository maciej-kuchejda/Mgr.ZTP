using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.BusinessCard.Producer.Clients
{
    public interface IBusinessCardClient
    {
        Task PostAsync<TBody>(string host, TBody body) where TBody : class;
    }
}
