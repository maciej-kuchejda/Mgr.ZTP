using Kuchejda.ZTP.BusinessCard.Producer.Providers;
using Kuchejda.ZTP.BusinessCard.Shared.Models;
using RandomNameGeneratorLibrary;

namespace Kuchejda.ZTP.BusinessCard.Producer.Services
{
    public class DataService : IDataService
    {
        private readonly IPersonNameGenerator _personNameGenerator;

        public DataService(IPersonNameGenerator personNameGenerator)
        {
            _personNameGenerator = personNameGenerator;
        }

        public IEnumerable<BusinessCardDTO> Generate(int bulkCount)
        {
            var result = new List<BusinessCardDTO>(bulkCount);

            for (int i = 0; i < bulkCount; i++)
            {
                IBusinessCardDataBuilder builder = new BusinessCardDataBuilder(_personNameGenerator, 10);

                var entity = builder
                    .WithRandomWebSite()
                    .WithRandomFirstName()
                    .WithRandomLastName()
                    .WithRandomTelephone()
                    .WithCompany()
                    .WithRandomEmail()
                    .Build();

                result.Add(entity);
            }

            return result;
        }
    }
}
