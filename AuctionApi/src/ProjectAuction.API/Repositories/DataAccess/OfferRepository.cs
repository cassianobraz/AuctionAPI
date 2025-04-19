using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly ProjectAuctionDbContext _dbContext;
    public OfferRepository(ProjectAuctionDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
