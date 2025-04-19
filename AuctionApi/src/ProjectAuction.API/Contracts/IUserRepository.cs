using ProjectAuction.API.Entities;

namespace ProjectAuction.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
