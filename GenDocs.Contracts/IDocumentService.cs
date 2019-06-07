using GenDocs.Dtos.DocumentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Contracts
{
    public interface IDocumentService
    {
        bool Create(DocumentCreateDto document);

        IEnumerable<DocumentListItemDto> GetAllDocuments();

        IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language);

        DocumentResponseDto GetDocumentById(int id);

        bool DeleteDocumentById(int id);
    }
}
