using Business.Abstract;
using DataAccess.Database.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class QuestionManager : IQuestionService
{
    private IQuestionDataAccess _questionDataAccess;

    public QuestionManager(IQuestionDataAccess questionDataAccess)
    {
        _questionDataAccess = questionDataAccess;
    }

    public Question Add(Question question) => _questionDataAccess.Add(question);

    public IList<Question> GetByExamId(int examId) => _questionDataAccess.GetList(q => q.ExamId == examId);

    public Question Update(Question question)
    {
        throw new NotImplementedException();
    }
}

