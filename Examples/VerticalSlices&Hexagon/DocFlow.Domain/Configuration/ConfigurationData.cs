using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Domain.Documents
{
  public class ConfigurationData : IConfigurationData
  {
    public QualitySystemType QualitySystem { get; set; }

    public EnvironmentType EnvType { get; set; }

    public bool ColorPrintingEnabled { get; set; }
  }
}