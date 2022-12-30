using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.WebApi.Validators
{
    public class BusinessCardValidator : IBusinessCardValidator
    {
        public IEnumerable<BusinessCardDTO> Validate(IEnumerable<BusinessCardDTO> dTOs)
        {
            var result = dTOs.DistinctBy(x => new { x.FirstName, x.LastName});

            return result;
        }
    }
}
