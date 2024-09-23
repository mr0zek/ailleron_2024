using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SFC.AdminApi.Features.AlertNotificationsWithUserData
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  public class AlertNotificationsWithUserDataController : Controller
  {       
    [HttpGet]
    public IActionResult Get([FromQuery] AlertNotificationsWithUserDataModel query)
    {
      // fill here

      return Ok();
    }
  }
}