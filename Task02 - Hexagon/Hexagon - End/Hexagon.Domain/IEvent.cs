using System;

namespace Hexagon
{
  public interface IEvent
  {
    string Id { get; }
    DateTime Created { get; }
  }
}