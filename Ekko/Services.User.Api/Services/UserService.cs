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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> GetUserById(Guid id)
        {
            if (id == Guid.Empty) { throw new BadRequestException("L'id utilisateur est nécessaire."); }

            var user = await _userRepository.GetUserById(id);

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<IEnumerable<UserListReadDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            return _mapper.Map<IEnumerable<UserListReadDto>>(users);
        }

        public async Task<IEnumerable<UserListReadDto>> GetUserByName(string username)
        {
            if (username == string.Empty) { throw new BadRequestException("Le nom d'utulisateur est nécessaire."); }

            var user = await _userRepository.GetUserByName(username);

            return _mapper.Map<IEnumerable<UserListReadDto>>(user);
        }

        public async Task<IEnumerable<UserListReadDto>> GetFriendsList(Guid id)
        {
            if (id == Guid.Empty) { throw new BadRequestException("L'id utilisateur est nécessaire"); }

            var usersFriends = await _userRepository.GetFriendsList(id);

            return _mapper.Map<IEnumerable<UserListReadDto>>(usersFriends);
        }
    }
}
