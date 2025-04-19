using Bogus;
using Moq;
using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;
using ProjectAuction.API.Enums;
using ProjectAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        //ARRANGE
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 700),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //ACT
        var auction = useCase.Execute();

        //ASSERT
        Assert.NotNull(auction);
        Assert.Equal(entity.Id, auction?.Id);
        Assert.Equal(entity.Name, auction?.Name);
    }
}
