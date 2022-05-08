using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Abstract;

public interface IExamService
{
    IList<Exam> GetList();
    Exam GetById(int id);
    Exam Add(Exam exam);
    Exam Update(Exam exam);

    ExamWithQuestion GetExamWithQuestionById(int id);
    ExamWithQuestion GetExamWithQuestionBySlug(string slug);
}

