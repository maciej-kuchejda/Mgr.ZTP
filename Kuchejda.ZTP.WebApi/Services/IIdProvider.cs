namespace Kuchejda.ZTP.WebApi.Services
{
    public interface IIdProvider
    {
        void SetUniqueIds(IList<BusinessCard.Shared.Models.BusinessCard> businessCards);
    }
}
