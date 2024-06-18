using AutoMapper;
using Common.Api.DTOs.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Services.User.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Models.User, UserReadDto>();
            CreateMap<Domain.Models.User, UserListReadDto>();
            CreateMap<Domain.Models.User, UserRegisterDto>();
            CreateMap<Domain.Models.User, UserUpdateDto>();
            CreateMap<Domain.Models.UserRelation, UserListReadDto>();
            CreateMap<Domain.Models.Friend, UserListReadDto>();

            CreateMap<UserReadDto, UserUpdateDto>();

            CreateMap<UserRegisterDto, Domain.Models.User>();
            CreateMap<UserUpdateDto, Domain.Models.User>();
        }
    }
}
