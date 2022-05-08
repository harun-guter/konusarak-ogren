using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    User Add(User user);
    bool CheckUser(User user);
    bool UserExists(User user);
}

