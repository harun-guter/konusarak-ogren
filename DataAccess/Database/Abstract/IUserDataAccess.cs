using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Database.Abstract;

public interface IUserDataAccess : IEntityRepository<User>
{
}

