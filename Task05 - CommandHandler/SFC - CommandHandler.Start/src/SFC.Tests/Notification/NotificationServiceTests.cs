using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Autofac;
using Microsoft.Extensions.Configuration;
using SFC.Notifications;
using SFC.Notifications.Services;
using SFC.SharedKernel;
using System.Linq;
using SFC.Tests.UseStories.Mocks;
using SFC.Tests.Mocks;

namespace SFC.Tests
{


  public class NotificationServiceTests
  {
    IContainer _container;

    public NotificationServiceTests()
    {
      var confBuilder = new ConfigurationBuilder()
        .AddJsonFile("appSettings.json");
      var configuration = confBuilder.Build();
      var connectionString = configuration["ConnectionStrings:DefaultConnection"];

      DbMigrations.Run(connectionString);

      var builder = new ContainerBuilder();
      builder.RegisterModule(new AutofacNotificationsModule(connectionString));
      builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
      builder.RegisterType<TestDateTimeProvider>().AsImplementedInterfaces();

      _container = builder.Build();      
    }

    [Fact]
    public void SendNotificationTest()
    {
      var notificationService = _container.Resolve<INotificationService>();
      
      LoginName loginName = "ala"+Guid.NewGuid();
      string notificationType = "type1";

      notificationService.SetNotificationEmail("example@exmaple.com", loginName);
      notificationService.SendNotification(loginName, "title", "body", notificationType);

      IEnumerable<NotificationsCountResult> result = notificationService.GetSendNotificationsCount(notificationType, loginName);

      Assert.True(result.Count() == 1);
      Assert.True(result.First().LoginName == loginName);
      Assert.True(result.First().Count == 1);
      Assert.True(TestSmtpClient.SentEmails.Count == 1);
    }
  }
}
