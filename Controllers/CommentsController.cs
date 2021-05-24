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
  [Route("api/[controller]")]
  public class CommentsController : ControllerBase
  {
    private readonly CommentsService _service;
    private readonly ProfilesService _profileService;
    public CommentsController(CommentsService service, ProfilesService profilesService)
    {
      _service = service;
      _profileService = profilesService;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Comment>> Create([FromBody] Comment newComment)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Profile fullProfile = _profileService.GetOrCreateAccountProfile(userInfo);
        newComment.CreatorId = userInfo.Id;

        Comment comment = _service.CreateComment(newComment);
        comment.Creator = fullProfile;
        return Ok(comment);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Comment> GetOneComment(int id)
    {
      try
      {
        Comment found = _service.GetOneComment(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Comment> EditComment(int id, [FromBody] Comment newComment)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Profile fullProfile = _profileService.GetOrCreateAccountProfile(userInfo);
        newComment.CreatorId = userInfo.Id;
        Comment comment = _service.CreateComment(newComment);
        comment.Creator = fullProfile;
        Comment found = _service.EditComment(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Comment>> DeleteComment(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.DeleteComment(id, userInfo.Id);
        return Ok("Comment Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}