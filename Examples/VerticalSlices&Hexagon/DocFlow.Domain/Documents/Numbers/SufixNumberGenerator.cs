using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;

namespace DocFlow.Domain.Documents.Numbers
{
  internal class SufixNumberGenerator : NumberGeneratorBase
  {
    private readonly string _sufix;
    private readonly User _currentUser;

    public SufixNumberGenerator(INumberGenerator numberGenerator, string sufix, User currentUser)
      : base(numberGenerator)
    {
      _sufix = sufix;
      _currentUser = currentUser;
    }

    public override DocumentNumber Generate()
    {
      if (_currentUser.HasRole<Auditor>())
      {
        return _numberGenerator.Generate().Append("_audit");
      }
      return _numberGenerator.Generate();
    }
  }
}