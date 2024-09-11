namespace DocFlow.Domain.Documents
{
  public class DocumentNumber
  {
    public string _number;

    public DocumentNumber(string number)
    {
      _number = number;
    }

    public override string ToString()
    {
      return _number;
    }

    public DocumentNumber Append(string text)
    {
      _number += text;
      return this;
    }
  }
}