
using System;
using DocFlow.Domain.Users;

namespace DocFlow.Infrastructure.Repo
{

  public class FakeUserRepository : IUserRepository
  {
    public User Get(string userId)
    {
      return new User(userId);
    }
  }
}