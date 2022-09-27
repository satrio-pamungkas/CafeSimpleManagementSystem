using CafeSimpleManagementSystem.Repositories;
using CafeSimpleManagementSystem.Helpers;

namespace CafeSimpleManagementSystem.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext context, UserRepository userRepository, JwtUtils jwtUtils
    ) {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateToken(token!);

        if (userId != Guid.Empty)
        {
            context.Items["User"] = userRepository.GetById(userId);
        }

        await _next(context);
    }
}