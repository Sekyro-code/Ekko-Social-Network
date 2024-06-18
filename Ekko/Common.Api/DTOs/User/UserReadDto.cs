using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.DTOs.User
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime Birthday { get; set; }
        public required string Email { get; set; }
        public string Biography { get; set; } = string.Empty;
        public required string Country { get; set; }
        public string Picture { get; set; } = string.Empty;
        public bool Private { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public bool Gender { get; set; }
        public int Notification { get; set; }
    }

}
