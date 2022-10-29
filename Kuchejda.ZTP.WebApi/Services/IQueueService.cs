namespace Kuchejda.ZTP.WebApi.Services
{
    public interface IQueueService
    {
        void Upload(IList<BusinessCard.Shared.Models.BusinessCard> businessCards);
    }
}
