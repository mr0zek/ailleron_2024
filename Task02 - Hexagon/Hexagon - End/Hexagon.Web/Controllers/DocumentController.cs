using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hexagon.Models;

namespace Hexagon.Controllers
{
  public class DocumentController : Controller
  {
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
      _documentService = documentService;
    }

    public IActionResult Create(string id)
    {
      _documentService.Create(id);
      return Ok();
    }

    public IActionResult Sign(string id, string userId)
    {
      _documentService.Sign(id, userId);
      return Ok();
    }

    public IActionResult Archive(string id)
    {
      _documentService.Archive(id);
      return Ok();
    }
  }
}
