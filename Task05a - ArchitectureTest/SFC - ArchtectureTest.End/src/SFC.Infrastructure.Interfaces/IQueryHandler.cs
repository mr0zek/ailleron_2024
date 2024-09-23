namespace SFC.Infrastructure.Interfaces
{
  public interface IQueryHandler<TRequest, TResult> where TRequest : IRequest<TResult> where TResult : IResponse
  {
    TResult HandleQuery(TRequest query);
  }

}
