using Common.Api.DTOs.User;

namespace Services.User.Api.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Domain.Models.User?> GetUserById(Guid id);
        Task<IEnumerable<Domain.Models.User>> GetAllUsers();
        Task<IEnumerable<Domain.Models.User>> GetUserByName(string username);
        Task<IEnumerable<Domain.Models.Friend>> GetFriendsList(Guid id);
    }
}
