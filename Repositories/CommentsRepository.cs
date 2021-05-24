using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using blogger.Models;
using Dapper;

namespace blogger.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;
    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Comment GetOneComment(int id)
    {
      string sql = @"
      SELECT
      c.*,
      p.*
      FROM comments c
      JOIN profiles p ON c.creatorId = p.id
      WHERE id = @id";
      return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) =>
      {
        comment.Creator = profile;
        return comment;
      }
      , new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Comment EditComment(int id)
    {
      string sql = @"
      UPDATE comments
      SET
        body = 
      ";
    }

    internal IEnumerable<Comment> GetAllBlogsComments(int id)
    {
      string sql = "SELECT * FROM comments WHERE blog = @id";
      return _db.Query<Comment>(sql, new { id });
    }

    internal Comment CreateComment(Comment newComment)
    {
      string sql = @"
      INSERT INTO comments
      (creatorId, body, blog)
      VALUE
      (@CreatorId, @Body, @Blog);
      SELECT LAST_INSERT_ID()";
      newComment.Id = _db.ExecuteScalar<int>(sql, newComment);
      return newComment;
    }

    internal bool DeleteComment(int id)
    {
      string sql = "DELETE FROM comments WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

  }
}