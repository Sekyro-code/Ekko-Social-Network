using AutoMapper;
using Common.Api.DTOs.User;
using Common.Api.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Services.User.Api.Domain.Models;
using Services.User.Api.Repositories;
using Services.User.Api.Repositories.Interface;
using Services.User.Api.Services.Interface;

namespace Services.User.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly SignInManager<Domain.Models.User> _signInManager;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, UserManager<Domain.Models.User> userManager, SignInManager<Domain.Models.User> signInManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;

        }

        public async Task<UserReadDto> LoginAsync(UserLoginDto userLogin)
        {

            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user == null)
            {
                throw new EkkoException("401", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "Email", new List<string> { "Aucun utilisateur trouvé." } } });
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userLogin.Password);

            if (!isPasswordValid)
            {
                throw new EkkoException("401", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "Password", new List<string> { "Mot de passe incorrect." } } });
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLogin.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException();
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<IdentityResult> RegisterAsync(UserRegisterDto userRegister)
        {

            var newUser = _mapper.Map<Domain.Models.User>(userRegister);
            var result = await _userManager.CreateAsync(newUser, userRegister.Password);

            if (result.Succeeded)
            {
                // Utilisez SignInManager pour générer et émettre un token JWT dans un cookie
                //await _signInManager.SignInAsync(newUser, isPersistent: false);
                await _signInManager.PasswordSignInAsync(newUser, userRegister.Password, false, lockoutOnFailure: false);

                return result;
            }

            return result;
        }

        public async Task<bool> GetUserByEmail(string email)
        {
            return await _accountRepository.GetUserByEmail(email);
        }

        public async Task<bool> GetUserByUsername(string username)
        {
            return await _accountRepository.GetUserByUsername(username);
        }
    }
}
