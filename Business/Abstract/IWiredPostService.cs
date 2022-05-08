using Entities.Concrete;

namespace Business.Abstract;

public interface IWiredPostService
{
    IList<WiredPost> GetPosts();
}
