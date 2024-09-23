using System.Collections.Generic;
using SFC.Alerts.Features.GetAllAlertCondition;
using SFC.Infrastructure.Interfaces;

namespace SFC.Alerts.Features.GetAllAlertConditions
{
  public class GetAllAlertConditionsResponse : IResponse
  {
    public class AlertResponse
    {
      public int Id { get; set; }
      public string ZipCode { get; set; }
    }

    public IEnumerable<AlertResponse> Alerts { get; }

    public GetAllAlertConditionsResponse(IEnumerable<AlertResponse> alerts)
    {
      Alerts = alerts;
    }
  }
}