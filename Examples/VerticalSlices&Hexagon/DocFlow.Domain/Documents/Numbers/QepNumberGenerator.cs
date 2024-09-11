using System;

namespace DocFlow.Domain.Documents.Numbers
{
  internal class QepNumberGenerator : INumberGenerator
  {
    public DocumentNumber Generate()
    {
      return new DocumentNumber(new Random().Next(1000).ToString());
    }
  }
}