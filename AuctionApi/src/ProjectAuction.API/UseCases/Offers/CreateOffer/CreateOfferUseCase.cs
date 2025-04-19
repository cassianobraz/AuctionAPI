using ProjectAuction.API.Entities;
using ProjectAuction.API.Communication.Requests;
using ProjectAuction.API.Repositories;
using ProjectAuction.API.Services;

namespace ProjectAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggetUser;
    public CreateOfferUseCase(LoggedUser loggetUser) => _loggetUser = loggetUser;
    public int Execute(int itemId, ResquestCreateOfferJson request)
    {
        var repository = new ProjectAuctionDbContext();

        var user = _loggetUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Offers.Add(offer);

        repository.SaveChanges();

        return offer.Id;
    }
}
