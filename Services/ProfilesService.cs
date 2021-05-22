using System;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateAccountProfile(Profile userInfo)
    {
      Profile profile = _repo.GetAccountById(userInfo.Id);
      if (profile == null)
      {
        return _repo.CreateAccount(userInfo);
      }
      return profile;
    }

    internal object getProfile(int id)
    {
      return _repo.getProfile(@id);
    }
  }
}