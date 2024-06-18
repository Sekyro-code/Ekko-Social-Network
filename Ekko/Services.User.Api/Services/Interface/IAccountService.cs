using Common.Api.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace Services.User.Api.Services.Interface
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(UserRegisterDto userRegister);
        Task<UserReadDto> LoginAsync(UserLoginDto userLogin);
        Task<bool> GetUserByEmail(string email);
        Task<bool> GetUserByUsername(string username);
    }
}
