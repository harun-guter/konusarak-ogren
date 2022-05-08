using Business.Abstract;
using Core.Entities.Concrete;
using Core.Helpers.Security;
using DataAccess.Database.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private IUserDataAccess _userDataAccess;

    public UserManager(IUserDataAccess userDataAccess)
    {
        _userDataAccess = userDataAccess;
    }

    public User Add(User user)
    {
        string hashedPassword = HashHelper.Hash(user.Password);
        user.Password = hashedPassword;
        return _userDataAccess.Add(user);
    }

    public bool CheckUser(User user)
    {
        var checkUser = _userDataAccess.Get(u => u.Username == user.Username && u.Password == HashHelper.Hash(user.Password));
        return checkUser != null;
    }

    public bool UserExists(User user)
    {
        var isExists = _userDataAccess.Get(u => u.Username == user.Username);
        return isExists == null;
    }
}

