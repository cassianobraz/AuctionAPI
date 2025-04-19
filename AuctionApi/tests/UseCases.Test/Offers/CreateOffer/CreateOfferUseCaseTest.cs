using Bogus;
using Moq;
using ProjectAuction.API.Communication.Requests;
using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;
using ProjectAuction.API.Services;
using ProjectAuction.API.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Fact]
    public void Success()
    {
        //ARRANGE
        var request = new Faker<ResquestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

        var mock = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, mock.Object);

        //ACT
        var id = useCase.Execute(0, request);

        //ASSERT
    }
}
