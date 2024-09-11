using Autofac;
using Autofac.Core;
using DocFlow.Application;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;
using DocFlow.WebApp.Features;
using DocFlow.WebApp.Infrastructure;

namespace DocFlow.WebApp
{
  internal class AutofacModule : Module
  {
    private string _connectionString;

    public AutofacModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(typeof(ICommandHandler<>).Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();      

      builder.RegisterType<DocumentFactory>().AsImplementedInterfaces();
      builder.RegisterType<NumberGeneratorFactory>().AsImplementedInterfaces();
      builder.RegisterType<CurrentUserProvider>().AsImplementedInterfaces();
      builder.RegisterType<FakeUserRepository>().AsImplementedInterfaces();
      builder.RegisterType<FakeDocumentRepository>().AsImplementedInterfaces();
      builder.RegisterType<CostCalculatorFactory>().AsImplementedInterfaces();
      builder.RegisterInstance(new ConfigurationData()
      {
        ColorPrintingEnabled = true,
        EnvType = Domain.Documents.Configuration.EnvironmentType.PROD,
        QualitySystem = Domain.Documents.Configuration.QualitySystemType.ISO
      }).AsImplementedInterfaces();

      //builder.RegisterType<MasterpieceFactory>().AsImplementedInterfaces();      
    }
  }
}