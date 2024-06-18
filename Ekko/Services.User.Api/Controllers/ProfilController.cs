using Common.Api.DTOs.User;
using Common.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.User.Api.Authentification;
using Services.User.Api.Services;
using Services.User.Api.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Services.User.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProfilController : BaseController
    {
        private readonly IProfilService _profilService;
        private readonly CurrentUserManager _currentUserManager;
        public ProfilController(IProfilService ProfilService, CurrentUserManager currentUserManager)
        {
            _profilService = ProfilService;
            _currentUserManager = currentUserManager;
        }

        [HttpGet()]
        [SwaggerOperation(Summary = "Récupère le profil connecté", Description = "Récupère le profil connecté")]
        [SwaggerResponse(200, "Le profil a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération du profil")]
        public async Task<ActionResult<UserReadDto>> GetProfil()
        {
            return await HandleExceptionAsync(async () =>
            {

                var userId = _currentUserManager.GetCurrentUser();
                return await _profilService.GetProfil(userId);
            });
        }

        [HttpPut("/edit")]
        [SwaggerOperation(Summary = "Récupère le profil connecté", Description = "Récupère le profil connecté")]
        [SwaggerResponse(200, "Le profil a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération du profil")]
        public async Task<ActionResult<UserReadDto>> UpdateProfil([FromBody] UserUpdateDto userUpdate)
        {
            return await HandleExceptionAsync(async () =>
            {
                var userId = _currentUserManager.GetCurrentUser();
                return await _profilService.UpdateUser(userId, userUpdate);
            });
        }

        [HttpGet("/list/friends")]
        [SwaggerOperation(Summary = "Récupère la liste d'amis", Description = "Récupère une liste d'amis de l'utilisateur")]
        [SwaggerResponse(200, "La liste d'amis a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération de la liste d'amis")]
        public async Task<ActionResult<IEnumerable<UserListReadDto>>> GetFriendsList()
        {
            return await HandleExceptionAsync(async () =>
            {
                var userId = _currentUserManager.GetCurrentUser();
                return await _profilService.GetFriendsList(userId);
            });
        }
    }
}
