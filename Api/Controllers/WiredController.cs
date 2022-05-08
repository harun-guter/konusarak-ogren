using Business.Abstract;
using DataAccess.Wired.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WiredController : ControllerBase
{
    private IWiredPostService _wiredPostService;
    WiredPostDataAccess _wiredPostDataAccess;

    public WiredController(IWiredPostService wiredPostService)
    {
        _wiredPostService = wiredPostService;
        _wiredPostDataAccess = new WiredPostDataAccess();
    }

    [HttpGet("getposts")]
    public IList<WiredPost> GetPosts() => _wiredPostDataAccess.DataAdapter();
    //public IList<WiredPost> GetPosts() => _wiredPostService.GetPosts(); //async refactor
}
