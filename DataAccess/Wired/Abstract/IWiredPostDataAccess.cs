using Entities.Concrete;

namespace DataAccess.Wired.Abstract;

public interface IWiredPostDataAccess
{
    string GetData(string url);
    IList<WiredPost> DataAdapter();
}

