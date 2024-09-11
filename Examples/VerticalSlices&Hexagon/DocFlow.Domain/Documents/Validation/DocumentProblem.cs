namespace DocFlow.Domain.Documents.Validation
{
  public class DocumentProblem
  {
    public string Description { get; private set; }
    public ProblemSeverity Severity { get; private set; }

    public DocumentProblem(string description, ProblemSeverity severity)
    {
      Description = description;
      Severity = severity;
    }

    public override string ToString()
    {
      return Severity + " : " + Description;
    }
  }
}