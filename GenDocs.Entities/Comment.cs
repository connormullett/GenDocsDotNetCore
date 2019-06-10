using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenDocs.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int DocumentId { get; set; }
        public int? ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
