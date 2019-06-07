﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenDocs.Dtos.UserDtos
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
