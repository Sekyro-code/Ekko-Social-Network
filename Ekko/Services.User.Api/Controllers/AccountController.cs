using Services.User.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Services.User.Api.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Services.Interface;
using Common.Api.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Common.Api.Auth;

namespace Services.User.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IJwtHandler _jwtHandler;
        public AccountController(IAccountService accountService, IJwtHandler jwtHandler)
        {
            _accountService = accountService;
            _jwtHandler = jwtHandler;
        }


        [HttpPost("register")]
        [SwaggerOperation(Summary = "Enregistre un utilisateur", Description = "Crée un utilisateur")]
        [SwaggerResponse(200, "L'utilisateur a été créé avec succès.")]
        [SwaggerResponse(500, "Une erreur s'est produite lors de la création d'un utilisateur")]
        public async Task<ActionResult<IdentityResult>> Register([FromBody] UserRegisterDto userRegister)
        {
            return await HandleExceptionAsync(async () =>
            {
                return await _accountService.RegisterAsync(userRegister);
            });
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Connecte un utilisateur", Description = "Connecte un utilisateur avec ses identifiants.")]
        [SwaggerResponse(200, "L'utilisateur a été connecté avec succès.")]
        [SwaggerResponse(401, "L'authentification a échoué. Les identifiants fournis sont incorrects.")]
        public async Task<ActionResult<UserReadDto>> Login([FromBody] UserLoginDto userLogin)
        {
            return await HandleExceptionAsync(async () =>
            {
                var user = await _accountService.LoginAsync(userLogin);

                var token = _jwtHandler.GenerateJwtToken(user.Id, user.Email);

                Response.Cookies.Append("Token", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true // Vous pouvez modifier ceci en fonction de votre configuration HTTPS
                });

                return user;
            });
        }
    }
}


