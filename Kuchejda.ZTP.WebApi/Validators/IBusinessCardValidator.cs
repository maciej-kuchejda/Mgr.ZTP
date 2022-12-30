using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.WebApi.Validators
{
    public interface IBusinessCardValidator
    {
        IEnumerable<BusinessCardDTO> Validate(IEnumerable<BusinessCardDTO> dTOs);
    }
}
