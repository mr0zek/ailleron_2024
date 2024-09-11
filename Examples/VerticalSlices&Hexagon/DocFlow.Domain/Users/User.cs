using System;
using System.Collections.Generic;
using DocFlow.Domain.Users.Roles;

namespace DocFlow.Domain.Users
{
  public class User
  {
    public string Id { get; private set; }
    private IDictionary<Type, IUserRole> _roles;

    public User(string id)
    {
      Id = id;

      //TODO wstrzyknąć w repo pobierając konf z podsystemu bezpieczeństwa
      _roles = new Dictionary<Type, IUserRole>();
    }

    public bool HasRole<T>()
    {
      return _roles.ContainsKey(typeof(T));
    }

    public IUserRole GetRole<T>() 
    {
      if (! HasRole<T>())
        throw new UnauthorizedOperationException(Id, "does not have role: " + typeof(T).Name);
      return _roles[typeof(T)];
    }
  }
}
