using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.DTOs.User
{
    public class UserUpdateDto
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime Birthday { get; set; }
        public required string Email { get; set; }
        public string Biography { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Picture { get; set; }
        public bool Private { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public bool Gender { get; set; }
    }
}
