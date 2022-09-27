using AutoMapper;
using BCrypt.Net;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Data;
using CafeSimpleManagementSystem.Wrappers.Auth;
using CafeSimpleManagementSystem.Helpers;

namespace CafeSimpleManagementSystem.Services;

public class AuthService : IAuthService
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

        if (_context.Users!.Any(p => p.Username == request.Username))
        {
            throw new AppException("Username " + request.Username + " is already taken");
        }
        
        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        _context.Users?.Add(user);
        _context.SaveChanges();

    }
}