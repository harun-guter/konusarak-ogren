using Business.Abstract;
using Core.Entities.Concrete;
using Core.Helpers.Security;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    IUserService _userService;
    IAccessTokenHelper _accessTokenHelper;

    public AuthManager(IUserService userService, IAccessTokenHelper accessTokenHelper)
    {
        _userService = userService;
        _accessTokenHelper = accessTokenHelper;
    }

    public AccessToken CreateAccessToken(User user) => _accessTokenHelper.CreateAccessToken(user);

    public bool Login(User user)
    {
        var checkUser = _userService.CheckUser(user); ;
        return checkUser;
    }

    public User Register(User user)
    {
        _userService.Add(user);
        return user;
    }
}
