using GenDocs.Contracts;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Tests.DocumentTests
{
    public class MockDocumentService : IDocumentService
    {
        public bool Create(Document document)
        {
            return true;
        }

        public bool DeleteDocumentById(int id)
        {
            return true;
        }

        public IEnumerable<DocumentListItemDto> GetAllDocuments()
        {
            return new List<DocumentListItemDto>()
            {
                new DocumentListItemDto()
                {
                    OwnerId = 1,
                    Title = "Title",
                    Content = "Content",
                    Language = "Python",
                    Id = 1,
                }
            };
        }

        public DocumentResponseDto GetDocumentById(int id)
        {
            return new DocumentResponseDto()
            {
                Id = 1,
                OwnerId = 1,
                Title = "Title",
                Content = "Content",
                Language = "Python",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
        }

        public IEnumerable<DocumentListItemDto> GetDocumentsByLanguage(string language)
        {
            return new List<DocumentListItemDto>()
            {
                new DocumentListItemDto()
                {
                    OwnerId = 1,
                    Title = "Title",
                    Content = "Content",
                    Language = "Python",
                    Id = 1,
                }
            };
        }

        public bool UpdateDocument(int id, DocumentUpdateDto model)
        {
            return true;
        }
    }
}
