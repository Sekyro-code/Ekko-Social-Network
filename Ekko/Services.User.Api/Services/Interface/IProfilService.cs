using Common.Api.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace Services.User.Api.Services.Interface
{
    public interface IProfilService
    {
        Task<UserReadDto> GetProfil(Guid id);
        Task<UserReadDto> UpdateUser(Guid id, UserUpdateDto userUpdate);
        Task<IEnumerable<UserListReadDto>> GetFriendsList(Guid id);
        Task<bool> GetUserByEmail(string email, Guid Id);
        Task<bool> GetUserByUsername(string username, Guid Id);
    }
}
