using DataAccess.Wired.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WiredController : ControllerBase
{
    [HttpGet("getposts")]
    public IList<WiredPost> GetPosts()
    {
        WiredPostDataAccess wiredPostDataAccess = new WiredPostDataAccess();
        return wiredPostDataAccess.DataAdapter();
    }
}
