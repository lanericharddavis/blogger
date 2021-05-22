using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blogger.Models;
using blogger.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _service;
    private readonly ProfilesService _profileService;
    public BlogsController(BlogsService service, ProfilesService profilesService)
    {
      _service = service;
      _profileService = profilesService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Blog>> GetAllBlogs()
    {
      try
      {
        IEnumerable<Blog> blogs = _service.GetAllBlogs();
        return Ok(blogs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Blog> GetOneBlog(int id)
    {
      try
      {
        return Ok(_service.GetOneBlog(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}/comments")]
    //TODO get all Blog's comments

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Profile fullProfile = _profileService.GetOrCreateAccountProfile(userInfo);
        newBlog.CreatorId = userInfo.Id;

        Blog blog = _service.CreateBlog(newBlog);
        blog.Creator = fullProfile;
        return Ok(blog);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // [HttpPut("{id}")]
    //TODO edit single Blog
    //NOTE Need to be authorized (can only modify your own)
    // [HttpDelete("{id}")]
    //TODO delete single Blog
    //NOTE Need to be authorized (can only modify your own)

  }
}