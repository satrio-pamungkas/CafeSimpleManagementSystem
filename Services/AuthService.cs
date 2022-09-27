using AutoMapper;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Data;
using CafeSimpleManagementSystem.Wrappers.Auth;
using CafeSimpleManagementSystem.Helpers;

namespace CafeSimpleManagementSystem.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly JwtUtils _jwtUtils;

    public AuthService(DataContext context, IMapper mapper, JwtUtils jwtUtils)
    {   
        _context = context;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
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

    public LoginResponse LoginUser(LoginRequest request)
    {
        var user = _context.Users!.SingleOrDefault(p => p.Username == request.Username);
        if (user == null)
        {
            throw new AppException("Username is not registered");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new AppException("Password is incorect");
        }

        var response = _mapper.Map<LoginResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }
}