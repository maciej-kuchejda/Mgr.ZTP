using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.BusinessCard.Producer.Services
{
    public interface IDataService
    {
        IEnumerable<BusinessCardDTO> Generate(int bulkCount);
    }
}
