using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.CommentDtos
{
    public class CommentListItemDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int? ReplyId { get; set; }
        public int DocumentId { get; set; }
        public string Content { get; set; }
    }
}
