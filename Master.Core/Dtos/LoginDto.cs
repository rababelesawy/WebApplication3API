﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Core.Dtos
{

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public  string  UserType { get; set; } // "Admin" or "User"
    }
}