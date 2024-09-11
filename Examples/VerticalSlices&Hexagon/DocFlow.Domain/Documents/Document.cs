using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Export;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Shared;
using DocFlow.Domain.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DocFlow.Domain.Documents
{
  public class Document
  {
    private readonly IDocumentValidator _validator;

    public DocumentNumber Number { get; private set; }

    public DocumentStatus Status { get; private set; }
    public string Id { get; }
    public DocumentType Type { get; private set; }

    public User Author { get; private set; }

    public string Title { get; private set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? ExpirationDate { get; private set; }

    public Money PrintingCost { get; private set; }

    public string Body { get; private set; }

    public decimal PageCount { get; private set; }

    public Document(string id, DocumentType type, User author, DocumentNumber documentNumber, IDocumentValidator validator)
    {
      _validator = validator;
      Id = id;
      Type = type;
      Author = author;

      Status = DocumentStatus.DRAFT;
      CreateDate = new DateTime();
      Number = documentNumber;
    }

    public void ChangeTitle(string newTitle)
    {
      if (newTitle == Title)
      {
        return;
      }
      if (Status == DocumentStatus.PUBLISHED || Status == DocumentStatus.ARCHIVED)
      {
        throw new DocumentOpeartionException(Number, "Can not change title if status is: " + Status);
      }
      Title = newTitle;
      Status = DocumentStatus.DRAFT;
    }

    //===== Flow ======

    public void Verify(User verifier)
    {
      if (Status != DocumentStatus.DRAFT)
      {
        throw new DocumentOpeartionException(Number, "Can not verify if status is: " + Status);
      }
      if (verifier.Equals(Author))
      {
        throw new DocumentOpeartionException(Number, "Can not verify by author");
      }
      var validationResult = _validator.Validate(this, DocumentStatus.VERIFIED);
      if (!validationResult.IsValid())
      {
        throw new ValidationException(validationResult.ToString());
      }

      Status = DocumentStatus.VERIFIED;
    }

    public void Publish(ICostCalculator costCalculator)
    {
      if (Status != DocumentStatus.VERIFIED)
      {
        throw new DocumentOpeartionException(Number, "Can not publish if status is: " + Status);
      }
      var validationResult = _validator.Validate(this, DocumentStatus.PUBLISHED);
      if (!validationResult.IsValid())
      {
        throw new ValidationException(validationResult.ToString());
      }
      Status = DocumentStatus.PUBLISHED;

      PrintingCost = costCalculator.Calculate(this);

      //TODO pozbyć się singletona!
      //EventsEngine.getInstance().publish(new DocumentPublishedEvent(number));
    }

    public void Archive()
    {
      var validationResult = _validator.Validate(this, DocumentStatus.ARCHIVED);
      if (!validationResult.IsValid())
      {
        throw new ValidationException(validationResult.ToString());
      }

      Status = DocumentStatus.ARCHIVED;
    }

    public void Export(IExporter exporter)
    {
      exporter.ExportAuthor(Author);
      exporter.ExportTitle(Title);
      exporter.ExportNumber(Number);
      exporter.ExportType(Type);
      exporter.ExportStatus(Status);
      exporter.ExportExpirationDate(ExpirationDate);      
    }
  }
}