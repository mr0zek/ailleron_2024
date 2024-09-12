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
      //IArchRule allowedPublicTypesInModules =
      //  Types().That();

      //allowedPublicTypesInModules.Check(Architecture);
    }           
  }
}
