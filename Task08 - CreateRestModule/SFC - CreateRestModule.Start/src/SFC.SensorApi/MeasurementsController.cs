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

    
  }
}