using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;
using System;
using System.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{

  public class NumberGeneratorFactory : INumberGeneratorFactory
  {
    private readonly ICurrentUserProvider _currentUserProvider;

    public NumberGeneratorFactory(ICurrentUserProvider currentUserProvider)
    {
      _currentUserProvider = currentUserProvider;
    }

    public INumberGenerator Create(IConfigurationData configurationData)
    {
      INumberGenerator result;

      result = CreateBase(configurationData);

      result = new SufixNumberGenerator(result, "Audit_", _currentUserProvider.Get());

      switch (configurationData.EnvType)
      {
        case EnvironmentType.DEMO:
          return new PrefixNumberGenerator(result, "Demo_");

        case EnvironmentType.PROD:
          break;
      }
      return result;
    }

    private static INumberGenerator CreateBase(IConfigurationData configurationData)
    {
      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          return new IsoNumberGenerator();

        case QualitySystemType.QEP:
          return new QepNumberGenerator();
      }
      throw new ConfigurationException();
    }    
  }
}