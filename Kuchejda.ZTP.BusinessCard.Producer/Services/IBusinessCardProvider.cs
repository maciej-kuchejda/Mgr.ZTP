using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kuchejda.ZTP.BusinessCard.Producer.Services
{
    internal interface IBusinessCardProvider
    {
        Task UploadAsync(IEnumerable<Shared.Models.BusinessCardDTO> models);
    }
}
