using GenDocs.Dtos.CommentDtos;
using GenDocs.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Contracts
{
    public interface ICommentService
    {
        bool Create(Comment comment);

        IEnumerable<CommentListItemDto> GetAllComments();

        IEnumerable<CommentListItemDto> GetCommentsByDocumentId(int documentId);

        IEnumerable<CommentListItemDto> GetCommentsByOwnerId(int ownerId);

        CommentResponseDto GetCommentById(int commentId);

        bool DeleteCommentById(int commentId);

        bool UpdateCommentById(int commentId, CommentUpdateDto comment);
    }
}
