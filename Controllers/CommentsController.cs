using blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CommentsController : ControllerBase
  {
    private readonly CommentsService _service;
    public CommentsController(CommentsService service)
    {
      _service = service;
    }


    // [HttpPost("{id}/comments")]
    //TODO create a new comment
    //NOTE Need to be logged in
    // [HttpPut("{id}")]
    //TODO edit single comment
    //NOTE Need to be authorized (can only modify your own)
    // [HttpDelete("{id}")]
    //TODO delete single comment
    //NOTE Need to be authorized (can only modify your own)

  }
}