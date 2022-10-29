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

        //public BusinessCardController(IBusinessCardValidator businessCardValidator,
        //    IIdProvider idProvider,
        //    IQueueService queueService)
        //{
        //    _queueService = queueService;
        //    _idProvider = idProvider;
        //    _businessCardValidator = businessCardValidator;
        //}

        [Route("bulk")]
        [HttpPost]
        public IActionResult CreateBusinessCard([FromBody]IList<BusinessCardDTO> businessCardDTOs )
        {
            _businessCardValidator.Validate(businessCardDTOs);

            var cards = businessCardDTOs.Cast<BusinessCard.Shared.Models.BusinessCard>().ToList();

            _idProvider.SetUniqueIds(cards);

            _queueService.Upload(cards);

            return Accepted();
        }
    }
}
