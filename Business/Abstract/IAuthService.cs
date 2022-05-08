using Core.Entities.Concrete;
using Core.Helpers.Security;

namespace Business.Abstract;

public interface IAuthService
{
    User Register(User user);
    bool Login(User user);
    AccessToken CreateAccessToken(User user);
}
