using DocFlow.Application;
using DocFlow.Application.PublishDocument;
using DocFlow.Domain.Documents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocFlow.WebApp.Features.PublishDocument
{
  [Route("api/documents")]
  [ApiController]
  public class PublishDocumentController : Controller
  {
    private readonly ICommandHandler<PublishDocumentCommand> _handler;

    public PublishDocumentController(ICommandHandler<PublishDocumentCommand> createDocumentHandler)
    {
      _handler = createDocumentHandler;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("{id}/publishers")]
    public IActionResult Publish(string id, [FromBody] PostPublisherRequest request)
    {
      _handler.Handle(new PublishDocumentCommand(
        id,
        request.PublisherId));

      return Ok();
    }
  }
}
