using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Database.Abstract;

public interface IQuestionDataAccess : IEntityRepository<Question>
{
}
