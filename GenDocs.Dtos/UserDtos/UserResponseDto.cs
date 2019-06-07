using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.UserDtos
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
