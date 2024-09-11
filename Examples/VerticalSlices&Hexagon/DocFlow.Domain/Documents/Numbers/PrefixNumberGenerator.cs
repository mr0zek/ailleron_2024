namespace DocFlow.Domain.Documents.Numbers
{
  internal class PrefixNumberGenerator : NumberGeneratorBase
  {
    private readonly string _prefix;

    public PrefixNumberGenerator(INumberGenerator numberGenerator, string prefix)
      : base(numberGenerator)
    {
      _prefix = prefix;
    }

    public override DocumentNumber Generate()
    {
      return new DocumentNumber(_prefix + _numberGenerator.Generate());
    }
  }
}