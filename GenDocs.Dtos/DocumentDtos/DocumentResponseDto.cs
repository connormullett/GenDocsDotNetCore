using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.DocumentDtos
{
    public class DocumentResponseDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
