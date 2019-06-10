using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenDocs.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly DataContext _context;

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
            var document = _context.Documents.Find(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public IEnumerable<DocumentListItemDto> GetAllDocuments()
        {
            // null is returned from EF if nothing is found from query
            return _context.Documents.Select(
                    x => new DocumentListItemDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Content = x.Content,
                        Language = x.Language,
                        OwnerId = x.OwnerId
                    }
                );
        }

        public DocumentResponseDto GetDocumentById(int id)
        {
            var document = _context.Documents.Find(id);
            if(document != null)
            {
                return new DocumentResponseDto()
                {
                    Id = document.Id,
                    OwnerId = document.OwnerId,
                    Title = document.Title,
                    Content = document.Content,
                    Language = document.Language,
                    CreatedAt = document.CreatedAt,
                    ModifiedAt = document.ModifiedAt
                };
            }
            return null;
        }

        public IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language)
        {
            return _context.Documents.Where(x => x.Language.ToLower() == language.ToLower()).Select(
                    x => new DocumentListItemDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Content = x.Content,
                        Language = x.Language,
                        OwnerId = x.OwnerId
                    }
                ).ToArray();
        }

        public IEnumerable<DocumentListItemDto> GetdocumentsByOwnerId(int id)
        {
            return _context.Documents.Where(x => x.OwnerId == id).Select(
                x =>  new DocumentListItemDto()
                {
                    Id = x.Id,
                    OwnerId = x.OwnerId,
                    Title = x.Title,
                    Content = x.Content,
                    Language = x.Language
                }
            );
        }

        public bool UpdateDocument(int id, DocumentUpdateDto model)
        {
            var documentToUpdate = _context.Documents.Find(id);

            documentToUpdate.Title = model.Title;
            documentToUpdate.Content = model.Content;
            documentToUpdate.Language = model.Language;
            documentToUpdate.ModifiedAt = DateTime.Now;

            _context.Documents.Update(documentToUpdate);
            return _context.SaveChanges() == 1;
        }
    }
}
