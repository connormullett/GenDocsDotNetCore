using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Services
{
    public class DocumentService : IDocumentService
    {
        private DataContext _context;

        public DocumentService(DataContext context)
        {
            _context = context;
        }

        public bool Create(Document document)
        {
            _context.Documents.Add(document);
            return _context.SaveChanges() == 1;
        }

        public bool DeleteDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _context.Documents;
        }

        public Document GetDocumentById(int id)
        {
            return _context.Documents.Find(id);
        }

        public IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language)
        {
            throw new NotImplementedException();
        }
    }
}
