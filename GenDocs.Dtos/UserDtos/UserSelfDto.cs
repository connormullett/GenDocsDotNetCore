using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Entities
{
    public class UserSelfDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int MyProperty { get; set; }
    }
}
