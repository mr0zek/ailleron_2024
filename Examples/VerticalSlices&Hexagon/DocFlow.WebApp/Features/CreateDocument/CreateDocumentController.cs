using DocFlow.Application;
using DocFlow.Application.CreateDocument;
using DocFlow.Domain.Documents;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DocFlow.WebApp.Features.CreateDocument
{
  [Route("api/documents")]
  [ApiController]
  public class CreateDocumentController : Controller
  {
    private readonly ICommandHandler<CreateDocumentCommand> _handler;

    public CreateDocumentController(ICommandHandler<CreateDocumentCommand> createDocumentHandler)
    {
      _handler = createDocumentHandler;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }

    [HttpPost]
    public IActionResult PostCreateDocument([FromBody] PostCreateDocumentRequest request)
    {
      var id = Guid.NewGuid().ToString();

      _handler.Handle(new CreateDocumentCommand(
        id,
        request.CreatorId, 
        Enum.Parse<DocumentType>(request.DocumentType), 
        request.Title));

      return Created("api/documents", id);
    }
  }
}
