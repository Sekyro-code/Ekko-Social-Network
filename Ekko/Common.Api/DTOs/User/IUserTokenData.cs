using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.DTOs.User
{
    public interface IUserTokenData
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public string? Picture { get; set; }
        public bool Private { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
