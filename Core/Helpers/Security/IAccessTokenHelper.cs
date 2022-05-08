using Core.Entities.Concrete;

namespace Core.Helpers.Security;

public interface IAccessTokenHelper
{
    AccessToken CreateAccessToken(User user);
}

