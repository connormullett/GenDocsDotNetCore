using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GenDocs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly AppSettings _appSettings;

        public DocumentsController(
            IDocumentService service,
            IOptions<AppSettings> appSettings)
        {
            _documentService = service;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]DocumentCreateDto documentDto)
        {
            if (_documentService.Create(documentDto))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}