using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        public int? ReplyId { get; set; }
        public int DocumentId { get; set; }
        public string Content { get; set; }
    }
}
