using Common.Api.DTOs.User;

namespace Services.User.Api.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Domain.Models.User> GetAsync(string email);
        Task<Domain.Models.User> AddAsync(Domain.Models.User newUser);
        Task<bool> GetUserByEmail(string email);
        Task<bool> GetUserByUsername(string username);
    }
}