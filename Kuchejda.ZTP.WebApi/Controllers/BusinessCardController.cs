using Kuchejda.ZTP.BusinessCard.Shared.Models;
using Kuchejda.ZTP.WebApi.Services;
using Kuchejda.ZTP.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Kuchejda.ZTP.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/business-cards")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BusinessCardController : ControllerBase
    {
        private readonly IQueueService _queueService;
        private readonly IIdProvider _idProvider;
        private readonly IBusinessCardValidator _businessCardValidator;

        public BusinessCardController(IBusinessCardValidator businessCardValidator,
            IIdProvider idProvider,
            IQueueService queueService)
        {
            _queueService = queueService;
            _idProvider = idProvider;
            _businessCardValidator = businessCardValidator;
        }

        [Route("bulk")]
        [HttpPost]
        public async Task<IActionResult> CreateBusinessCard([FromBody]IList<BusinessCardDTO> businessCardDTOs )
        {
            var distictend = _businessCardValidator.Validate(businessCardDTOs).ToList();

            var cards = distictend.Select(x=> new BusinessCard.Shared.Models.BusinessCard(x)).ToList();

            _idProvider.SetUniqueIds(cards);

            await _queueService.UploadAsync(cards);

            return Accepted();
        }
    }
}
