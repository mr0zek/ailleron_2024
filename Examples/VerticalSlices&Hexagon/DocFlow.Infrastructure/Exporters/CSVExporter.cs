using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Export;
using DocFlow.Domain.Users;
using System;
using System.IO;
using System.Text;

namespace DocFlow.Infrastructure.Exporters
{
  public class CSVExporter : IExporter
  {
    private string _author;
    private string _status;
    private string _title;
    private string _number;
    private string _expirationDate;
    private string _type;

    public Stream GetResult()
    {
      string result = string.Format("{0};{1};{2};{3};{4};{5}", _number, _title, _status, _type, _expirationDate, _author);
      return new MemoryStream(Encoding.UTF8.GetBytes(result));
    }

    public void ExportAuthor(User author)
    {
      _author = author.ToString();
    }

    public void ExportExpirationDate(DateTime? expirationDate)
    {
      _expirationDate = expirationDate.ToString();
    }

    public void ExportStatus(DocumentStatus status)
    {
      _status = status.ToString();
    }

    public void ExportTitle(string title)
    {
      _title = title;
    }

    public void ExportNumber(DocumentNumber number)
    {
      _number = number.ToString();
    }

    public void ExportType(DocumentType type)
    {
      _type = type.ToString();
    }
  }
}