using DocFlow.Domain.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Documents.Export
{
  public interface IExporter
  {
    void ExportAuthor(User author);

    void ExportTitle(string title);

    void ExportExpirationDate(DateTime? expirationDate);

    void ExportStatus(DocumentStatus status);

    void ExportNumber(DocumentNumber number);

    void ExportType(DocumentType type);

    Stream GetResult();
  }
}