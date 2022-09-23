namespace CafeSimpleManagementSystem.Wrappers.Auth;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? ExpiresIn { get; set; }
}