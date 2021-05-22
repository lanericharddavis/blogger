using System;
using System.Threading.Tasks;
using blogger.Models;
using blogger.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class AccountController : ControllerBase
  {
    private readonly ProfilesService _service;
    public AccountController(ProfilesService service)
    {
      _service = service;
    }

    [HttpGet]
    //get your account
    //NOTE need to be logged in
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Profile currentUser = _service.GetOrCreateProfile(userInfo);
        return Ok(currentUser);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    // [HttpGet]
    //TODO get all your blogs
    //NOTE need to be logged in
    // [HttpGet]
    //TODO get all your comments
    //NOTE need to be logged in
    // [HttpPut]
    //TODO edit your own profile
    //NOTE Need to be authorized (can only modify your own)
  }
}