using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocFlow.Domain.Documents.Validation
{
  public class ValidationResult
  {
    private List<DocumentProblem> _list = new List<DocumentProblem>();

    public void Add(DocumentProblem problem)
    {
      _list.Add(problem);
    }

    public bool IsValid()
    {
      return _list.Count == 0;
    }

    public override string ToString()
    {
      return string.Join(",", _list.Select(f => f.Description));
    }
  }
}