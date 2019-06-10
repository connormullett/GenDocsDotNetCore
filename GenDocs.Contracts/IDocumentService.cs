using GenDocs.Dtos.DocumentDtos;
using GenDocs.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Contracts
{
    public interface IDocumentService
    {
        bool Create(Document document);

        IEnumerable<DocumentListItemDto> GetAllDocuments();

        IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language);

        DocumentResponseDto GetDocumentById(int id);

        bool DeleteDocumentById(int id);

        bool UpdateDocument(int id, DocumentUpdateDto model);

        IEnumerable<DocumentListItemDto> GetdocumentsByOwnerId(int id);
    }
}
