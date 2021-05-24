using System;
using System.Collections.Generic;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;
    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    internal Comment GetOneComment(int id)
    {
      Comment comment = _repo.GetOneComment(id);
      if (comment == null)
      {
        throw new Exception("Invalid Comment Id");
      }
      return comment;
    }

    // internal Comment EditComment(int id)
    // {
    //   Comment comment = _repo.EditComment(id);
    //   if (comment == null)
    //   {
    //     throw new Exception("Invalid Comment Id");
    //   }
    //   return comment;
    // }

    internal IEnumerable<Comment> GetAllBlogsComments(int id)
    {
      return _repo.GetAllBlogsComments(id);
    }

    internal Comment CreateComment(Comment newComment)
    {
      return _repo.CreateComment(newComment);
    }

    internal void DeleteComment(int id, string creatorId)
    {
      Comment comment = GetOneComment(id);
      if (comment.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete another users Comment");
      }
      if (!_repo.DeleteComment(id))
      {
        throw new Exception("Something has gone wrong, review code");
      }
    }

  }
}