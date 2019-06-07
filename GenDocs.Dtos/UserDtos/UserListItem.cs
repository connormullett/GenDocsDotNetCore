using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.UserDtos
{
    // User's Dto when appearing in Search query
    public class UserListItem
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
