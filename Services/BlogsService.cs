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

    internal object GetOneBlog(int id)
    {
      return _repo.GetOneBlog(@id);
    }

    internal Blog CreateBlog(Blog newBlog)
    {
      return _repo.CreateBlog(newBlog);
    }

  }
}