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

        public DocumentsController(
            IDocumentService service,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _documentService = service;
            _mapper = mapper;
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

        [AllowAnonymous]
        [HttpGet("bylanguage/{language}")]
        public IActionResult GetDocumentsByLanguage(string language)
        {
            var documents = _documentService.GetDocumentsByLanguage(language);
            return Ok(documents);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]DocumentUpdateDto document)
        {
            // DocumentService.Update() NEEDS the former values and is 
            // on the client to provide the old values and new ones
            var queriedDocument = _documentService.GetDocumentById(id);
            if(queriedDocument.OwnerId != int.Parse(User.Identity.Name))
            {
                return StatusCode(401);
            }

            var response = _documentService.UpdateDocument(id, document);
            if (response)
            {
                return Ok();
            }
            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_documentService.DeleteDocumentById(id))
            {
                return StatusCode(204);
            }
            return StatusCode(404);
        }
    }
}