using System;
using Xunit;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using ArchUnitNET.xUnit;
using FluentMigrator;
using System.Linq;
using System.Text.RegularExpressions;
using SFC.Infrastructure;
using System.Xml.Linq;
using ArchUnitNET.Fluent.Predicates;
using System.Collections.Generic;
using ArchUnitNET.Domain.Extensions;
using SFC.Notifications;
using Autofac.Core;
using RestEase;
using SFC.Infrastructure.Interfaces;
using Autofac;

namespace SFC.Tests.Architecture
{


  public class ArchitectureTests
  {
    private static readonly ArchUnitNET.Domain.Architecture Architecture =
    new ArchLoader().LoadAssemblies(
      typeof(AutofacNotificationsModule).Assembly).Build();

    [Fact]
    public void CheckPublicTypesInModules()
    {
      IArchRule allowedPublicTypesInModules =
        Types().That()
        .ResideInAssembly("SFC.Notification.*", true).And()
          .DoNotResideInAssembly(typeof(ICommand).Assembly).And()
          .AreNotAssignableTo(typeof(Migration)).And()
          .AreNotAssignableTo(typeof(Exception)).And()
          .AreNotAssignableTo(typeof(Module)).And()
          .DoNotImplementInterface(typeof(IRequest<>)).And()
          .DoNotImplementInterface(typeof(IResponse)).And()
          .DoNotImplementInterface(typeof(ICommand)).And()
          .DoNotImplementInterface(typeof(IEvent))
          .Should().NotBePublic();

      allowedPublicTypesInModules.Check(Architecture);
    }           
  }
}
