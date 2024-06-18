using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.Auth
{
    public interface IJwtHandler
    {
        string GenerateJwtToken(Guid Id, string Email);
    }
}
