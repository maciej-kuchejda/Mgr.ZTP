using Kuchejda.ZTP.BusinessCard.Shared.Models;

namespace Kuchejda.ZTP.BusinessCard.Producer.Providers
{
    public interface IBusinessCardDataBuilder
    {
        IBusinessCardDataBuilder WithRandomFirstName();
        IBusinessCardDataBuilder WithRandomLastName();
        IBusinessCardDataBuilder WithRandomTelephone();
        IBusinessCardDataBuilder WithRandomWebSite();
        IBusinessCardDataBuilder WithCompany();
        IBusinessCardDataBuilder WithRandomEmail();

        BusinessCardDTO Build();
    }
}
