using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Database.Abstract;
using DataAccess.Database.Concrete.EntityFramework.Contexts;

namespace DataAccess.Database.Concrete.EntityFramework;

public class UserDataAccess : EntityRepositoryBase<User, KonusarakOgrenContext>, IUserDataAccess
{
}
