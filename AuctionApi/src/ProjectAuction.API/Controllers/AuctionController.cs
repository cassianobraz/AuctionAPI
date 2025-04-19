using Microsoft.AspNetCore.Mvc;
using ProjectAuction.API.Entities;
using ProjectAuction.API.UseCases.Auctions.GetCurrent;

namespace ProjectAuction.API.Controllers;

public class AuctionController : ProjectAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}

