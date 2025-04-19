using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
