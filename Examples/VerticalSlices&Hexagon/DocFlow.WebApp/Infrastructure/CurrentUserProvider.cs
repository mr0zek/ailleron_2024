using DocFlow.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocFlow.WebApp.Infrastructure
{
  public class CurrentUserProvider : ICurrentUserProvider
  {
    public User Get()
    {
      return new User("testUser");
    }
  }
}
