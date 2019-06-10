using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenDocs.Entities
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
