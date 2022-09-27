using CafeSimpleManagementSystem.Wrappers.Auth;

namespace CafeSimpleManagementSystem.Services;

public interface IAuthService
{
    void RegisterUser(RegisterRequest request);
}