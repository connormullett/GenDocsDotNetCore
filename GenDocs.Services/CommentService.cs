using GenDocs.Contracts;
using GenDocs.Dtos.CommentDtos;
using GenDocs.Entities;
using GenDocs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDocs.Services
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }

        public bool Create(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges() == 1;
        }

        public bool DeleteCommentById(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if(comment != null)
            {
                _context.Comments.Remove(comment);
                return _context.SaveChanges() == 1;
            }

            return false;
        }

        public IEnumerable<CommentListItemDto> GetAllComments()
        {
            return _context.Comments.Select(
                x => new CommentListItemDto()
                {
                    Id = x.Id,
                    Content = x.Content,
                    DocumentId = x.DocumentId,
                    OwnerId = x.OwnerId,
                    ReplyId = x.ReplyId,
                }
            );
        }

        public CommentResponseDto GetCommentById(int commentId)
        {
            var comment = _context.Comments.Find(commentId);

            if(comment != null)
            {
                return new CommentResponseDto()
                {
                    Id = comment.Id,
                    OwnerId = comment.OwnerId,
                    Content = comment.Content,
                    CreatedAt = comment.CreatedAt,
                    DocumentId = comment.DocumentId,
                    ModifiedAt = comment.ModifiedAt,
                    ReplyId = comment.ReplyId
                };
            }
            return null;
        }

        public IEnumerable<CommentListItemDto> GetCommentsAsListItemsByDocument(int documentId)
        {
            return _context.Comments.Where(x => x.DocumentId == documentId).Select(
                x => new CommentListItemDto()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReplyId = x.ReplyId,
                    DocumentId = x.DocumentId,
                    OwnerId = x.OwnerId
                });
        }

        public IEnumerable<CommentResponseDto> GetCommentsByDocumentId(int documentId)
        {
            return _context.Comments.Where(x => x.DocumentId == documentId).Select(
                x => new CommentResponseDto()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReplyId = x.ReplyId,
                    DocumentId = x.DocumentId,
                    OwnerId = x.OwnerId,
                    ModifiedAt = x.ModifiedAt,
                    CreatedAt = x.CreatedAt,
                });
        }

        public IEnumerable<CommentResponseDto> GetCommentsByOwnerId(int ownerId)
        {
            return _context.Comments.Where(x => x.OwnerId == ownerId).Select(
                x => new CommentResponseDto()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ReplyId = x.ReplyId,
                    DocumentId = x.DocumentId,
                    OwnerId = x.OwnerId,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                }).ToArray();
        }

        public CommentResponseDto GetParentCommentById(int commentId)
        {
            var comment = _context.Comments.Find(commentId);

            var parentComment = _context.Comments.Find(comment.ReplyId);

            return new CommentResponseDto()
            {
                Id = parentComment.Id,
                Content = parentComment.Content,
                DocumentId = parentComment.DocumentId,
                OwnerId = parentComment.OwnerId,
                CreatedAt = parentComment.CreatedAt,
                ModifiedAt = parentComment.ModifiedAt,
                ReplyId = parentComment.ReplyId
            };
        }

        public bool UpdateCommentById(int commentId, CommentUpdateDto commentDto)
        {
            var comment = _context.Comments.Find(commentId);

            comment.Id = commentDto.Id;
            comment.OwnerId = commentDto.OwnerId;
            comment.Content = commentDto.Content;

            _context.Comments.Update(comment);
            return _context.SaveChanges() == 1;
        }
    }
}
