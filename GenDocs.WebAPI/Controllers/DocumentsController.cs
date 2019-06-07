using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GenDocs.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public DocumentsController(
            IDocumentService service,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _documentService = service;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("create")]
        public IActionResult Post([FromBody]DocumentCreateDto documentDto)
        {
            Document document = _mapper.Map<Document>(documentDto);

            document.OwnerId = int.Parse(User.Identity.Name);
            document.CreatedAt = DateTime.Now;

            try
            {
                // save the document
                if (_documentService.Create(document))
                {
                    return Ok();
                }
                // if it didnt save, it's our fault
                return StatusCode(500);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllDocuments()
        {
            var documents = _documentService.GetAllDocuments();
            var documentListItems = _mapper.Map<IList<DocumentListItemDto>>(documents);
            return Ok(documentListItems);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var document = _documentService.GetDocumentById(id);
            var documentDto = _mapper.Map<DocumentResponseDto>(document);
            return Ok(documentDto);
        }
    }
}