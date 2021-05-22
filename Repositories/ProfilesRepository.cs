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
    internal Profile GetAccountById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile CreateAccount(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (id, name, picture, email)
      VALUES
      (@Id, @Name, @Picture, @Email)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }

    internal object getProfile(int id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }
  }
}