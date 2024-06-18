using AutoMapper;
using Common.Api.DTOs.User;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Data;
using Services.User.Api.Domain.Models;
using Services.User.Api.Repositories.Interface;

namespace Services.User.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.User?> GetUserById(Guid id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Domain.Models.User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.User>> GetUserByName(string username)
        {
            return await _context.Users.Where(u => u.UserName.ToLower().Contains(username.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Friend>> GetFriendsList(Guid id)
        {
            var relations = await _context.UserFriends.Where(uf => uf.UserId == id).ToListAsync();

            List<Friend> listFriends = new List<Friend>();

            if (relations != null)
            {
                foreach (var relation in relations)
                {
                    var friend = await _context.Users.SingleOrDefaultAsync(u => u.Id == relation.FriendId);

                    listFriends.Add(new Friend
                    {
                        Id = friend.Id,
                        UserName = friend.UserName,
                        Picture = friend.Picture,
                        Biography = friend.Biography,
                        Country = friend.Country,
                        Birthday = friend.Birthday,
                        FirstName = friend.FirstName,
                        LastName = friend.LastName,
                        CreatedAt = friend.CreatedAt,
                    });
                }
            }

            return listFriends;
        }
    }
}
