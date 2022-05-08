using Business.Abstract;
using DataAccess.Wired.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class WiredPostManager : IWiredPostService
{
    private IWiredPostDataAccess _wiredPostDataAccess;

    public WiredPostManager(IWiredPostDataAccess wiredPostDataAccess)
    {
        _wiredPostDataAccess = _wiredPostDataAccess;
    }

    public IList<WiredPost> GetPosts() => _wiredPostDataAccess.DataAdapter();
}
