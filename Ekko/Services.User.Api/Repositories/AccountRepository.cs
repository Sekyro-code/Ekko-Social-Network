using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Data;
using Services.User.Api.Repositories.Interface;

namespace Services.User.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Domain.Models.User> AddAsync(Domain.Models.User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public Task<Domain.Models.User> GetAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> GetUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> GetUserByUsername(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }
    }
}
