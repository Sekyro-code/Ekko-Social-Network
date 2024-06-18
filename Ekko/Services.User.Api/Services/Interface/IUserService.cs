using Common.Api.DTOs.User;

namespace Services.User.Api.Services.Interface
{
    public interface IUserService
    {
        Task<UserReadDto> GetUserById(Guid id);
        Task<IEnumerable<UserListReadDto>> GetAllUsers();
        Task<IEnumerable<UserListReadDto>> GetUserByName(string username);
        Task<IEnumerable<UserListReadDto>> GetFriendsList(Guid id);
    }
}
