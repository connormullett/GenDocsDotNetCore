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

        IEnumerable<Document> GetAllDocuments();

        IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language);

        Document GetDocumentById(int id);

        bool DeleteDocumentById(int id);
    }
}
