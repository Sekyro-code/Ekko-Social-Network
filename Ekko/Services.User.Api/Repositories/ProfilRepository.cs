using AutoMapper;
using Common.Api.DTOs.User;
using Common.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Data;
using Services.User.Api.Domain.Models;
using Services.User.Api.Repositories.Interface;

namespace Services.User.Api.Repositories
{
    public class ProfilRepository : IProfilRepository
    {
        private readonly AppDbContext _context;

        public ProfilRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.User?> GetProfil(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Domain.Models.User?> GetUserByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Domain.Models.User?> GetUserByUsername(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<Domain.Models.User> UpdateUser(Domain.Models.User updateUser)
        {
            _context.Users.Update(updateUser);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                return updateUser;
            }
            else
            {
                throw new EkkoException("500", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "User", new List<string> { "Une erreur c'est produit, aucune modification n'a été enregistrée." } } });
            }
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
