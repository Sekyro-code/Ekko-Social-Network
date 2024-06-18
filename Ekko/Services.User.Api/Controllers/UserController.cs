using Services.User.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Services.User.Api.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Services.Interface;
using Common.Api.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Common.Api.Exceptions;

namespace Services.User.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/user/{id:guid}")]
        [SwaggerOperation(Summary = "Récupère un utilisateur", Description = "Récupère un utilisateur en fonction de l'id")]
        [SwaggerResponse(200, "L'utilisateur a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération d'un utilisateur")]
        public async Task<ActionResult<UserReadDto>> GetUserById([SwaggerParameter("Id de l'utilisateur")] Guid id)
        {
            return await HandleExceptionAsync(async () =>
            {

                return await _userService.GetUserById(id);

            });
        }

        [HttpGet("/users")]
        [SwaggerOperation(Summary = "Récupère liste d'utilisateurs", Description = "Récupère une list d'utilisateurs")]
        [SwaggerResponse(200, "Les utilisateurs a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération des utilisateurs")]
        public async Task<ActionResult<IEnumerable<UserListReadDto>>> GetAllUsers()
        {
            return await HandleExceptionAsync(async () =>
            {
                return await _userService.GetAllUsers();
            });
        }

        [HttpGet("/user/{username}")]
        [SwaggerOperation(Summary = "Récupère un utilisateur", Description = "Récupère un utilisateur par le son nom")]
        [SwaggerResponse(200, "L'utilisateur a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération d'un utilisateur")]
        public async Task<ActionResult<IEnumerable<UserListReadDto>>> GetUserByName([SwaggerParameter("Nom d'utilisateur")] string username)
        {
            return await HandleExceptionAsync(async () =>
            {
                return await _userService.GetUserByName(username);
            });
        }

        [HttpGet("/user/{id:guid}/list/friends")]
        [SwaggerOperation(Summary = "Récupère les amis de l'utilisateurs", Description = "Récupère une liste d'amis de l'utilisateur par son id")]
        [SwaggerResponse(200, "La liste d'amis a été récupéré avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la récupération de la liste d'amis")]
        public async Task<ActionResult<IEnumerable<UserListReadDto>>> GetFriendsList([SwaggerParameter("Id de l'utilisateur")] Guid id)
        {
            return await HandleExceptionAsync(async () =>
            {
                return await _userService.GetFriendsList(id);
            });
        }
    }

}


