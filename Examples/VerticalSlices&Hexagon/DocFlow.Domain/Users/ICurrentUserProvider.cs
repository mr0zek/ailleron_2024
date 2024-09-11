using DocFlow.Domain.Users;

namespace DocFlow.Domain.Users
{
  public interface ICurrentUserProvider
  {
    User Get();
  }
}