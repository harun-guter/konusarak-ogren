namespace Entities.Concrete.Dtos;
public class ExamWithQuestion
{
    public Exam Exam { get; set; }
    public List<Question> Questions { get; set; }
}
