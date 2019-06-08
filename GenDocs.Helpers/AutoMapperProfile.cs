using AutoMapper;
using GenDocs.Dtos.CommentDtos;
using GenDocs.Dtos.DocumentDtos;
using GenDocs.Dtos.UserDtos;
using GenDocs.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mappings
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();


            // Document Mappings
            CreateMap<DocumentCreateDto, Document>();
            CreateMap<Document, DocumentResponseDto>();

            CreateMap<Document, DocumentListItemDto>();
            CreateMap<DocumentListItemDto, Document>();

            
            // Comment Mappings
            CreateMap<Comment, CommentListItemDto>();
            CreateMap<CommentListItemDto, Comment>();

            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CommentResponseDto, Comment>();

            CreateMap<CommentCreateDto, Comment>();
            CreateMap<Comment, CommentCreateDto>();
        }
    }
}
