using System;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SFC.Alerts;
using SFC.Infrastructure;
using SFC.Infrastructure.Interfaces;
using SFC.Notifications;
using SFC.Processes;
using SFC.Sensors;
using SFC.UserApi;

namespace SFC
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var confBuilder = new ConfigurationBuilder()
        .AddJsonFile("appSettings.json");
      var configuration = confBuilder.Build();
      var connectionString = configuration["ConnectionStrings:DefaultConnection"];

      DbMigrations.Run(connectionString);

      Bootstrap.Run(args, new Module[]
      {
        new AutofacUserApiModule(),
        new AutofacAlertsModule(),
        new AutofacProcessesModule(),
        new AutofacNotificationsModule(),
        new AutofacSensorsModule(),
        new AutofacInfrastructureModule()
    });

      Console.ReadKey();
    }
  }
}
