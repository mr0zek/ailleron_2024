using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SFC.AdminApi.Features.SearchableDashboard
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/admin/[controller]")]
  [ApiController]
  public class SearchableDashboardController : Controller
  {        
    [HttpGet]
    public IActionResult Get([FromQuery]SearchableDashboardQueryModel query)
    {
      // fill here
      
      return Json(new string[0]);
    }
  }
}