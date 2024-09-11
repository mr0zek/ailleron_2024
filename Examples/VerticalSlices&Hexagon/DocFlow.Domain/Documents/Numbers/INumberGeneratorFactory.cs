using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
  public interface INumberGeneratorFactory
  {
    INumberGenerator Create(IConfigurationData configurationData);
  }
}