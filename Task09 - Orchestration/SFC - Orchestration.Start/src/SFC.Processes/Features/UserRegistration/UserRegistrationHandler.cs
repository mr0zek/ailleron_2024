using Automatonymous;
using SFC.Accounts.Features.CreateAccount.Contract;
using SFC.Accounts.Features.GetAccountByLoginName;
using SFC.Alerts.Features.RegisterAlertCondition.Contract;
using SFC.Infrastructure.Interfaces;
using SFC.Notifications.Features.SendNotification.Contract;
using SFC.Notifications.Features.SetNotificationEmail.Contract;
using SFC.Processes.Features.UserRegistration.Contract;
using System;

namespace SFC.Processes.Features.UserRegistration
{
  class UserRegistrationHandler // implement handlers
  {
    private readonly ICommandBus _commandBus;
    private readonly IQuery _query;
    
    public UserRegistrationHandler(ICommandBus commandBus, IQuery query)
    {
      _commandBus = commandBus;
      _query = query;
    }    
  }
}