using Core.DataAccess.EntityFramework;
using DataAccess.Database.Abstract;
using DataAccess.Database.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Database.Concrete.EntityFramework;

public class QuestionDataAccess : EntityRepositoryBase<Question, KonusarakOgrenContext>, IQuestionDataAccess
{
}

