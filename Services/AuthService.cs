using AutoMapper;
using BCrypt.Net;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Data;
using CafeSimpleManagementSystem.Wrappers.Auth;

namespace CafeSimpleManagementSystem.Services;

public class AuthService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AuthService(DataContext context, IMapper mapper)
    {   
        _context = context;
        _mapper = mapper;
    }

    public void RegisterUser(RegisterRequest request)
    {

        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        _context.Users?.Add(user);
        _context.SaveChanges();

    }
}