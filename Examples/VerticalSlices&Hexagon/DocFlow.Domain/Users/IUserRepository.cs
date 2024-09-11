using System;

namespace DocFlow.Domain.Users
{
  public interface IUserRepository
  {
    User Get(string userId);
  }
}
