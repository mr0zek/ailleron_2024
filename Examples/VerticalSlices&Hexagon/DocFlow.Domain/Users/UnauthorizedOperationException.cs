using System;
using System.Security;

namespace DocFlow.Domain.Users
{
  public class UnauthorizedOperationException : SecurityException
  {
    public string UserId { get; private set; }

    public UnauthorizedOperationException(string userId, string message) : base(message)
    {
      UserId = userId;
    }    
  }
}