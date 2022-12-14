using Microsoft.AspNetCore.Mvc;
using CafeSimpleManagementSystem.Wrappers;
using CafeSimpleManagementSystem.Wrappers.Auth;
using CafeSimpleManagementSystem.Services;

namespace CafeSimpleManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        _authService!.RegisterUser(request);
        var payload = new Response<object>()
        {
            Status = 200,
            Message = "Success",
            Data = new { message = "User is succesfully created" }
        };
        return Ok(payload);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var response = _authService!.LoginUser(request);
        return Ok(response);
    }

    // [HttpPost("refresh")]
    // public IActionResult RefreshToken(RefreshTokenRequest request)
    // {

    // }

}
