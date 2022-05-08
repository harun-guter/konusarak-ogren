using Core.Entities.Abstract;

namespace Core.Entities.Concrete;
public class User : IEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }
}