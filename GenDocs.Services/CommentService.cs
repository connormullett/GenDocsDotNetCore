using GenDocs.Contracts;
using GenDocs.Dtos.CommentDtos;
using GenDocs.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Services
{
    public class CommentService : ICommentService
    {
        public bool Create(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemDto> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public CommentResponseDto GetCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemDto> GetCommentsByDocumentId(int documentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemDto> GetCommentsByOwnerId(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCommentById(int commentId, CommentUpdateDto comment)
        {
            throw new NotImplementedException();
        }
    }
}
