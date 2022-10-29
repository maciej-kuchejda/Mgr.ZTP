using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.WebApi.Validators
{
    public interface IBusinessCardValidator
    {
        void Validate(IList<BusinessCardDTO> dTOs);
    }
}
