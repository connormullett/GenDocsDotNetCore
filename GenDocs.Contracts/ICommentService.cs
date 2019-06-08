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

        IEnumerable<CommentResponseDto> GetCommentsByDocumentId(int documentId);

        IEnumerable<CommentListItemDto> GetCommentsAsListItemsByDocument(int documentId);

        IEnumerable<CommentListItemDto> GetCommentsByOwnerId(int ownerId);

        CommentResponseDto GetCommentById(int commentId);

        CommentResponseDto GetParentCommentById(int commentId);

        bool DeleteCommentById(int commentId);

        bool UpdateCommentById(int commentId, CommentUpdateDto comment);
    }
}
