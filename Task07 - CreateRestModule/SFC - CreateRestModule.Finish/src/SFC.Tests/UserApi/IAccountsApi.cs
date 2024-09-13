using System;
using System.Threading.Tasks;
using RestEase;

namespace SFC.Tests.UserApi
{
  public interface IUserApi
  {
    [Post("api/v1.0/user/sensors")]
    Task<Guid> PostSensor([Body] PostSensorModel model);
  }
}