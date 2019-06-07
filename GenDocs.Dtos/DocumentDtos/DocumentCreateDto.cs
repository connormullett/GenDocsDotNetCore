using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.DocumentDtos
{
    public class DocumentCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
    }
}
