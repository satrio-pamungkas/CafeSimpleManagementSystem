using AutoMapper;
using CafeSimpleManagementSystem.Wrappers.Auth;
using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<RegisterRequest, User>();
    }
}
