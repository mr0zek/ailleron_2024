using SFC.SharedKernel;

namespace SFC.Notifications.DataAccess
{
  internal interface IEmailRepository
  {
    Email GetEmail(LoginName loginName);
    void Set(LoginName loginName, Email email);
  }
}