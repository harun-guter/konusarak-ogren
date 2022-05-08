using Business.Abstract;
using Core.Helpers.Url;
using DataAccess.Database.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete;

public class ExamManager : IExamService
{
    private IExamDataAccess _examDataAccess;
    private IQuestionDataAccess _questionDataAccess;

    public ExamManager(IExamDataAccess examDataAccess, IQuestionDataAccess questionDataAccess)
    {
        _examDataAccess = examDataAccess;
        _questionDataAccess = questionDataAccess;
    }

    public Exam Add(Exam exam)
    {
        exam.Slug = SlugHelper.Generate();
        exam.IsDeleted = false;
        exam.Date = DateTime.Now;
        return _examDataAccess.Add(exam);
    }

    public Exam Delete(Exam exam) => _examDataAccess.Delete(exam);

    public Exam GetById(int id) => _examDataAccess.Get(e => e.Id == id);

    public ExamWithQuestion GetExamWithQuestionById(int id)
    {
        var questionListByExamId = _questionDataAccess.GetList(q => q.ExamId == id);
        var exam = new ExamWithQuestion
        {
            Exam = _examDataAccess.Get(e => e.Id == id),
            Questions = questionListByExamId.ToList()
        };
        return exam;
    }

    public ExamWithQuestion GetExamWithQuestionBySlug(string slug)
    {
        var exam = _examDataAccess.Get(e => e.Slug == slug);
        var questionListByExamId = _questionDataAccess.GetList(q => q.ExamId == exam.Id);
        return new ExamWithQuestion
        {
            Exam = exam,
            Questions = questionListByExamId.ToList()
        };
    }

    public IList<Exam> GetList() => _examDataAccess.GetList(e => e.IsDeleted == false);

    public Exam Update(Exam exam) => _examDataAccess.Update(exam);
}

