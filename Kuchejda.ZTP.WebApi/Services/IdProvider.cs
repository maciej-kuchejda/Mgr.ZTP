using Kuchejda.ZTP.BusinessCard.Shared.Models;
using Kuchejda.ZTP.WebApi.Generatos;

namespace Kuchejda.ZTP.WebApi.Services
{
    public class IdProvider : IIdProvider
    {
        private readonly IIdGenerator _idGenerator;

        public IdProvider(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }
        public void SetUniqueIds(IList<BusinessCard.Shared.Models.BusinessCard> businessCards)
        {
            var amount = businessCards.Count * 2;

            foreach (var item in businessCards)
            {
                var newUniqueId = _idGenerator.GenerateUniqueId(amount);

                item.Id = newUniqueId;
            }
        }
    }
}
