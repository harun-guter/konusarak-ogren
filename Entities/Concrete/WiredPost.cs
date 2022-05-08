using Core.Entities.Abstract;

namespace Entities.Concrete;

public class WiredPost : IEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
}
