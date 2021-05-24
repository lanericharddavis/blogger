using System;
using System.Collections.Generic;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;
    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Blog> GetAllBlogs()
    {
      return _repo.GetAllBlogs();
    }

    internal Blog GetOneBlog(int id)
    {
      Blog blog = _repo.GetOneBlog(id);
      if (blog == null)
      {
        throw new Exception("Invalid Blog Id");
      }
      return blog;
    }

    internal Blog CreateBlog(Blog newBlog)
    {
      return _repo.CreateBlog(newBlog);
    }

    internal void DeleteBlog(int id, string creatorId)
    {
      Blog comment = GetOneBlog(id);
      if (comment.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete another users Blog");
      }
      if (!_repo.DeleteBlog(id))
      {
        throw new Exception("Something has gone wrong, review code");
      }
    }
  }
}