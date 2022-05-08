using Core.Entities.Abstract;

namespace Entities.Concrete;
public class Question : IEntity
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public string Text { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string KeyOption { get; set; }
}