namespace Kuchejda.ZTP.WebApi.Services
{
    public interface IQueueService
    {
        Task UploadAsync(IList<BusinessCard.Shared.Models.BusinessCard> businessCards);
    }
}
