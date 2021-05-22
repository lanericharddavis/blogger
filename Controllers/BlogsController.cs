using blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _service;
    public BlogsController(BlogsService service)
    {
      _service = service;
    }

    // [HttpGet]
    //TODO get all published blogs
    // [HttpGet("{id}")]
    //TODO get a single Blog
    // [HttpGet("{id}/comments")]
    //TODO get all Blog's comments
    // [HttpPost("{id}")]
    //TODO create single Blog
    //NOTE Need to be logged in
    // [HttpPut("{id}")]
    //TODO edit single Blog
    //NOTE Need to be authorized (can only modify your own)
    // [HttpDelete("{id}")]
    //TODO delete single Blog
    //NOTE Need to be authorized (can only modify your own)

  }
}