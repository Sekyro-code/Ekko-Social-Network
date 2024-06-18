using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.DTOs.User
{
    public class UserListReadDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public string Picture { get; set; } = string.Empty;
        public bool Private { get; set; }
    }
}
