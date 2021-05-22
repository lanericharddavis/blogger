using System;
using blogger.Models;
using blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    public ProfilesController(ProfilesService service)
    {
      _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(int id)
    {
      try
      {
        return Ok(_service.getProfile(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // [HttpGet("{id}/blogs")]
    //TODO get all of that profile's blogs
    // [HttpGet("{id}/comments")]
    //TODO get all of that profile's comments
  }
}