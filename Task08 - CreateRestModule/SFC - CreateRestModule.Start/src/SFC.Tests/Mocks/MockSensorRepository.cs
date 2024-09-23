using Moq;
using SFC.Sensors.Features.RegisterMeasurement;
using SFC.SharedKernel;
using System;

namespace SFC.Tests.Mocks
{
  internal class MockSensorRepository : ISensorRepository
  {
    public void Add(Guid sensorId, ZipCode zipCode, LoginName loginName)
    {      
    }

    public bool Exits(Guid sensorId)
    {
      return true;
    }
  }
}