using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenDocs.Contracts;
using GenDocs.Dtos.CommentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenDocs.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public ActionResult Create(CommentCreateDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);

            comment.OwnerId = int.Parse(User.Identity.Name);
            comment.CreatedAt = DateTime.Now;

            try
            {
                if (_service.Create(comment))
                {
                    return Ok();
                }
                return StatusCode(500);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// used for getting all comments for a documents views
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("bydocument/{documentId}")]
        public ActionResult<IEnumerable<CommentResponseDto>> GetCommentsByDocumentId(int documentId)
        {
            var comments = _service.GetCommentsByDocumentId(documentId);

            if(comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<CommentResponseDto>> GetAllComments()
        {
            var comments = _service.GetAllComments();

            if(comments != null)
            {
                return Ok(comments);
            }

            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CommentResponseDto> GetCommentByCommentId(int id)
        {
            CommentResponseDto comment = _service.GetCommentById(id);

            if(comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("getparent/{commentId}")]
        public ActionResult<CommentResponseDto> GetParentCommentByReplyId(int commentId)
        {
            var comment = _service.GetParentCommentById(commentId);

            if(comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        [HttpGet("byowner/{ownerId}")]
        public ActionResult<IEnumerable<CommentResponseDto>> GetCommentsByOwnerId(int ownerId)
        {
            var comments = _service.GetCommentsByOwnerId(ownerId);

            if(comments != null)
            {
                return Ok(comments);
            }

            return NotFound();
        }

        [HttpPut("update/{commentId}")]
        public ActionResult Update(int commentId, CommentUpdateDto commentDto)
        {
            var comment = _service.GetCommentById(commentId);

            if(comment.OwnerId != int.Parse(User.Identity.Name))
            {
                return Unauthorized();
            }

            if(_service.UpdateCommentById(commentId, commentDto))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var comment = _service.GetCommentById(id);

            if(comment.OwnerId != int.Parse(User.Identity.Name))
            {
                return Unauthorized();
            }

            if (_service.DeleteCommentById(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}