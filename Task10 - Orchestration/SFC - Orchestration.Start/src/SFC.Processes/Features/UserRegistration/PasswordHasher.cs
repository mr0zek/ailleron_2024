using System.Security.Cryptography;
using System.Text;

namespace SFC.Processes.Features.UserRegistration
{
  class PasswordHasher : IPasswordHasher
  {
    public string Hash(string password)
    {
      var md5 = new MD5CryptoServiceProvider();
      return Encoding.ASCII.GetString(md5.ComputeHash(Encoding.ASCII.GetBytes(password)));
    }
  }
}