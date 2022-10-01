using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Wrappers.Auth;

namespace CafeSimpleManagementSystem.Services;

public interface IAuthService
{
    void RegisterUser(RegisterRequest request);
    void SaveRefreshToken(User user);
    LoginResponse LoginUser(LoginRequest request);
    // LoginResponse RefreshToken(RefreshTokenRequest request);
}