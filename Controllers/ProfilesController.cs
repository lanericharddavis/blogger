using blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    public ProfilesController(ProfilesService service)
    {
      _service = service;
    }

    // [HttpGet("{id}")]
    //TODO get a single profile
    // [HttpGet("{id}/blogs")]
    //TODO get all profile's blogs
    // [HttpGet("{id}/comments")]
    //TODO get all profile's comments
  }
}