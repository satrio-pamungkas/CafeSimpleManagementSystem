using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CafeSimpleManagementSystem.Config;

public static class JwtConfiguration
{
    public static IServiceCollection AddJwtAuth(
        this IServiceCollection services, 
        IConfiguration config ) 
    {
        services.AddAuthentication(x => 
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o => 
        {
            var Key = Encoding.UTF8.GetBytes(config.GetValue<string>("JWT:Key"));
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config.GetValue<string>("JWT:Issuer"),
                ValidAudience = config.GetValue<string>("JWT:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Key)
            };
        });

        return services;
    }
}