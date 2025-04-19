using Microsoft.EntityFrameworkCore;
using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly ProjectAuctionDbContext _dbContext;
    public AuctionRepository(ProjectAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
