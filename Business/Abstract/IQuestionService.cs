using Entities.Concrete;

namespace Business.Abstract;

public interface IQuestionService
{
    IList<Question> GetByExamId(int examId);
    Question Add(Question question);
    Question Update(Question question);
}

