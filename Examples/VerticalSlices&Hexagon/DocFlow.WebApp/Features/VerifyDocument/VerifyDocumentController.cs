using DocFlow.Application;
using DocFlow.Application.VerifyDocument;
using DocFlow.Domain.Documents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocFlow.WebApp.Features.VerifyDocument
{
  [Route("api/documents")]
  [ApiController]
  public class VerifyDocumentController : Controller
  {
    private readonly ICommandHandler<VerifyDocumentCommand> _handler;

    public VerifyDocumentController(ICommandHandler<VerifyDocumentCommand> createDocumentHandler)
    {
      _handler = createDocumentHandler;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("{id}/verifiers")]
    public IActionResult PostVerifier(string id, [FromBody] PostVerifierRequest request)
    {      
      _handler.Handle(new VerifyDocumentCommand(
        id,
        request.VerifierId));

      return Ok();
    }
  }
}
