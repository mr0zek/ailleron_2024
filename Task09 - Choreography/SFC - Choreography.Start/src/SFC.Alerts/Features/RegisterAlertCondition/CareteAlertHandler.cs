using SFC.Alerts.Features.RegisterAlertCondition.Contract;
using SFC.Infrastructure;
using SFC.Infrastructure.Interfaces;

namespace SFC.Alerts.Features.RegisterAlertCondition
{
  internal class CareteAlertHandler : ICommandHandler<CreateAlertCommand>
  {
    private readonly IAlertRepository _repository;

    public CareteAlertHandler(IAlertRepository repository)
    {
      _repository = repository;
    }

    public void Handle(CreateAlertCommand command)
    {
      if (_repository.Exists(command.ZipCode, command.LoginName))
      {
        throw new AlertExistsException(command.ZipCode);
      }

      _repository.Add(command.ZipCode, command.LoginName);

      
    }
  }
}
