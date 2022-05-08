using Core.Entities.Abstract;

namespace Entities.Concrete;
public class Exam : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Slug { get; set; }
    public DateTime Date { get; set; }
    public bool IsDeleted { get; set; }
}
