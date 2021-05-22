using System;
using System.Data;
using blogger.Models;
using Dapper;

namespace blogger.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;
    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO accounts
      (id, name, picture, email)
      VALUES
      (@Id, @Name, @Picture, @Email)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}