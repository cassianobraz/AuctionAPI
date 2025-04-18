using Microsoft.EntityFrameworkCore;
using ProjectAuction.API.Entities;
using ProjectAuction.API.Repositories;

namespace ProjectAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction Execute()
    {
        var repository = new ProjectAuctionDbContext();

        return repository
            .Auctions
            .Include(auction => auction.Items)
            .First();
    }
}
