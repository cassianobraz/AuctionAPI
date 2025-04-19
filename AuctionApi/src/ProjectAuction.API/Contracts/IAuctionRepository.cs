using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
