using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.DocumentDtos
{
    public class DocumentListItemDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // Content should be shortened to first 50 or so characters on return
        public string Language { get; set; }
    }
}
