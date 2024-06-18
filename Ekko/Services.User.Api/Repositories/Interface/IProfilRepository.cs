using Common.Api.DTOs.User;

namespace Services.User.Api.Repositories.Interface
{
    public interface IProfilRepository
    {
        Task<Domain.Models.User?> GetProfil(Guid id);
        Task<Domain.Models.User> UpdateUser(Domain.Models.User updateUser);
        Task<Domain.Models.User?> GetUserByEmail(string email);
        Task<Domain.Models.User?> GetUserByUsername(string username);
        Task<IEnumerable<Domain.Models.Friend>> GetFriendsList(Guid id);
    }
}
