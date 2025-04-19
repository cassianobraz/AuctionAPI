using ProjectAuction.API.Communication.Requests;
using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;
using ProjectAuction.API.Services;

namespace ProjectAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggetUser;
    private readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggetUser, IOfferRepository repository)
    {
        _loggetUser = loggetUser;
        _repository = repository;
    }
    public int Execute(int itemId, ResquestCreateOfferJson request)
    {
        var user = _loggetUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        _repository.Add(offer);

        return offer.Id;
    }
}
