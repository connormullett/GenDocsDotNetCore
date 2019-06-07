using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Services
{
    public class DocumentService : IDocumentService
    {
        public bool Create(DocumentCreateDto document)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentListItemDto> GetAllDocuments()
        {
            throw new NotImplementedException();
        }

        public DocumentResponseDto GetDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language)
        {
            throw new NotImplementedException();
        }
    }
}
