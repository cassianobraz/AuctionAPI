using Microsoft.AspNetCore.Mvc;
using ProjectAuction.API.Communication.Requests;
using ProjectAuction.API.Filters;
using ProjectAuction.API.UseCases.Offers.CreateOffer;

namespace ProjectAuction.API.Controllers;

public class OfferController : ProjectAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] ResquestCreateOfferJson resquest,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, resquest);

        return Created(string.Empty, id);
    }
}
