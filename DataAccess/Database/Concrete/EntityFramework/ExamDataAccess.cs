using Core.DataAccess.EntityFramework;
using DataAccess.Database.Abstract;
using DataAccess.Database.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Database.Concrete.EntityFramework;

public class ExamDataAccess : EntityRepositoryBase<Exam, KonusarakOgrenContext>, IExamDataAccess
{
}

