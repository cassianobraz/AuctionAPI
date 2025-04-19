using ProjectAuction.API.Contracts;
using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ProjectAuctionDbContext _dbContext;
    public UserRepository(ProjectAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    } 

    public User GetUserByEmail(string email) => _dbContext.Users.First(User => User.Email.Equals(email));

}
