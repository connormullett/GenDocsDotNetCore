using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenDocs.Contracts;
using GenDocs.Dtos.CommentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenDocs.WebAPI.Controllers
{
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
    }
}