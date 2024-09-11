namespace Hexagon
{
  public interface IEventPublisher
  {
    void Publish(IEvent @event);
  }
}