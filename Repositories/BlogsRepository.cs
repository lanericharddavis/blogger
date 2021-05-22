using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using blogger.Models;
using Dapper;

namespace blogger.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;
    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Blog> GetAllBlogs()
    {
      string sql = @"
      SELECT
      b.*,
      p.*
      FROM blogs b
      JOIN profiles p ON b.creatorId = p.id;";
      return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) =>
      {
        blog.Creator = profile;
        return blog;
      }, splitOn: "id");
    }

    internal object GetOneBlog(int id)
    {
      string sql = @"
      SELECT
      b.*,
      p.*
      FROM blogs b
      JOIN profiles p ON b.creatorId = p.id
      WHERE id = @id";
      return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) =>
      {
        blog.Creator = profile;
        return blog;
      }
      , new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Blog CreateBlog(Blog newBlog)
    {
      string sql = @"
      INSERT INTO blogs
      (title, body, imgUrl, published, creatorId)
      VALUES
      (@Title, @Body, @ImgUrl, @Published, @CreatorId);
      SELECT LAST_INSERT_ID()";
      newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
      return newBlog;
    }
  }
}