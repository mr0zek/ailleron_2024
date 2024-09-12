using SFC.SharedKernel;

namespace SFC.Notifications.Services
{
  public interface ISmtpClient
  {
    void Send(Email email, string title, string body);
  }
}