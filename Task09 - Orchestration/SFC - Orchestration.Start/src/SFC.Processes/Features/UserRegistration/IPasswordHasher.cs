namespace SFC.Processes.Features.UserRegistration
{
  public interface IPasswordHasher
  {
    string Hash(string password);
  }
}