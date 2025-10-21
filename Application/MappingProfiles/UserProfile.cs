using AutoMapper;
using Domain;
using Shared.Dto.AuthDto;
using Shared.Dto.UserDto;

namespace Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserResponseDto>().ReverseMap();
        CreateMap<UserEntity, UserUpdateDto>().ReverseMap();
        
        CreateMap<UserRegistrationDto, UserEntity>().ReverseMap();
        CreateMap<UserLoginDto, UserEntity>().ReverseMap();
    }
}