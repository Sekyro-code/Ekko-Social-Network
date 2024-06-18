using AutoMapper;
using Common.Api.DTOs.User;
using Common.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using Services.User.Api.Domain.Models;
using Services.User.Api.Repositories;
using Services.User.Api.Repositories.Interface;
using Services.User.Api.Services.Interface;

namespace Services.User.Api.Services
{
    public class ProfilService : IProfilService
    {
        private readonly IProfilRepository _profilRepository;
        private readonly IMapper _mapper;

        public ProfilService(IProfilRepository profilRepository, IMapper mapper)
        {
            _profilRepository = profilRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> GetProfil(Guid id)
        {
            var user = await _profilRepository.GetProfil(id);
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<bool> GetUserByEmail(string email, Guid Id)
        {
            var user = await _profilRepository.GetUserByEmail(email);
            if (user != null && user.Id == Id)
            {
                return true;
            }
            else if (user != null && user.Id != Id)
            {
                return false;
            }
            else if (user == null)
            {
                return true;
            }
            throw new EkkoException("422", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "User", new List<string> { "Une erreur c'est produit, aucune modification n'a été enregistrée." } } });
        }

        public async Task<bool> GetUserByUsername(string username, Guid Id)
        {
            var user = await _profilRepository.GetUserByUsername(username);
            if (user != null && user.Id == Id)
            {
                return true;
            }
            else if (user != null && user.Id != Id)
            {
                return false;
            }
            else if (user == null)
            {
                return true;
            }
            throw new EkkoException("422", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "User", new List<string> { "Une erreur c'est produit, aucune modification n'a été enregistrée." } } });
        }

        public async Task<UserReadDto> UpdateUser(Guid id, UserUpdateDto userUpdate)
        {
            var existingUser = await _profilRepository.GetProfil(id);
            if (existingUser == null)
            {
                throw new EkkoException("404", "One or more validation errors occurred.", new Dictionary<string, List<string>> { { "User", new List<string> { "Utilisateur non trouvé." } } });
            }

            _mapper.Map(userUpdate, existingUser);

            var user = await _profilRepository.UpdateUser(existingUser);

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<IEnumerable<UserListReadDto>> GetFriendsList(Guid id)
        {
            if (id == Guid.Empty) { throw new BadRequestException("L'id utilisateur est nécessaire"); }

            var usersFriends = await _profilRepository.GetFriendsList(id);

            return _mapper.Map<IEnumerable<UserListReadDto>>(usersFriends);
        }
    }
}
