using Common.Api.DTOs.User;
using Common.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Data;
using Services.User.Api.Services.Interface;
using System.Security.Claims;

namespace Services.User.Api.Authentification
{
    public class CurrentUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProfilService _profilService;
        public CurrentUserManager(IHttpContextAccessor httpContextAccessor, IProfilService profilService)
        {
            _httpContextAccessor = httpContextAccessor;
            _profilService = profilService;
        }
        public Guid GetCurrentUser()
        {
            var currentUser = _httpContextAccessor?.HttpContext?.User;
            if (currentUser?.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedAccessException();
            }
            var userIdClaim = currentUser?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new EkkoException("401", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "User", new List<string> { "L'ID de l'utilisateur n'a pas été trouvé." } } });
            }
            return Guid.Parse(userIdClaim.Value);
        }
    }
}
