using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int? Status { get; set; }
    }
}
