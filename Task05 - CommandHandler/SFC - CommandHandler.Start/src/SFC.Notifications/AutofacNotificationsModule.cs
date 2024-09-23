using Autofac;
using SFC.Infrastructure;
using SFC.Infrastructure.Interfaces;
using SFC.Notifications.DataAccess;
using SFC.Notifications.Services;

namespace SFC.Notifications
{

  public class AutofacNotificationsModule : Module
  {
    private readonly string _connectionString;

    public AutofacNotificationsModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<EmailRepository>()
        .AsImplementedInterfaces()
        .WithParameter("connectionString", _connectionString);

      builder.RegisterType<NotificationRepository>()
        .AsImplementedInterfaces()
        .WithParameter("connectionString", _connectionString);

      builder.RegisterType<NotificationService>()
        .AsImplementedInterfaces();
        

      // How to register all types that implements ICommandHandler<>
      //builder.RegisterAssemblyTypes(GetType().Assembly)
      //  .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
      //  .InstancePerLifetimeScope();

    }
  }
}
