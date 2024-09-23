using FluentValidation;

namespace SFC.Accounts.Features.SearchAccount
{
  class SearchAccountRequestValidator : AbstractValidator<SearchAccountRequest>
  {
    public SearchAccountRequestValidator()
    {
      RuleFor(f=>f.Take).NotNull().GreaterThan(0);
      RuleFor(f => f.Skip).GreaterThanOrEqualTo(0);
   }
  }
}