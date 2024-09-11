using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Validation.chain;
using DocFlow.Domain.Documents.Validation.Criteria;
using DocFlow.Domain.Documents.Validation.Criteria.ISO;
using DocFlow.Domain.Documents.Validation.Criteria.QEP;
using System.Configuration;

namespace DocFlow.Domain.Documents.Validation
{
  public class DocumentValidatorFactory
  {
    public static IDocumentValidator Create(IConfigurationData configurationData)
    {
      ManagerDocumentValidator validator = new ManagerDocumentValidator();

      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          validator.AddCritetion(new NumberValidator(DocumentStatus.VERIFIED));
          validator.AddCritetion(new ExpiryDateValidator(DocumentStatus.PUBLISHED));
          break;

        case QualitySystemType.QEP:
          validator.AddCritetion(new AuthorValidator(DocumentStatus.VERIFIED));
          validator.AddCritetion(new ExpiryDateValidator(DocumentStatus.VERIFIED));
          validator.AddCritetion(new BodyValidator(DocumentStatus.PUBLISHED));
          break;

        default:
          throw new ConfigurationException("Invalid quality system in configuration");
      }

      return validator;
    }
  }
}