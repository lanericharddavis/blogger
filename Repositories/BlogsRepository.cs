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

    //NOTE unable to populate profiles on blogs after trying to get by Id.  Postman keeps sending a 400 Bad Request: Column 'id' in where clause is ambiguous
    internal Blog GetOneBlog(int id)
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

    internal bool DeleteBlog(int id)
    {
      string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

  }
}