using Autofac;
using SFC.AdminApi.Features.AlertNotificationsWithUserData;
using SFC.Infrastructure.Interfaces;

namespace SFC.AdminApi
{
  public class AutofacAdminApiModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {            
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}
