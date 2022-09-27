using Microsoft.AspNetCore.Mvc;
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
        return Ok(new { message = "Success create user" });
    }

}
