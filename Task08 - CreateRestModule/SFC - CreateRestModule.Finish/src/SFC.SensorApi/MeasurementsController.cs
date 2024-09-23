using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SFC.Infrastructure;
using SFC.Infrastructure.Interfaces;
using SFC.Sensors.Features.RegisterMeasurement.Contract;

namespace SFC.SensorApi
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}")]
  [ApiController]
  public class MeasurementsController : Controller
  {
    private readonly ICommandBus _commandBus;

    public MeasurementsController(ICommandBus commandBus)
    {
      _commandBus = commandBus;
    }

    [HttpPost("sensors/{sensorId}/measurements")]
    public IActionResult Post([FromRoute] Guid sensorId, [FromBody] PostMeasurementModel model)
    {
      var d = model.Values.Select(f => new Tuple<ElementName, decimal>(new ElementName(f.Key), f.Value)).ToList();

      _commandBus.Send(new RegisterMeasurementCommand()
      {
        SensorId = sensorId,
        Elements = d.ToDictionary(f => f.Item1, f => f.Item2),
        Date = DateTime.Now,
        Id = Guid.NewGuid()
      });
      return Ok();
    }
  }
}