using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SmartCartBackend.API.Authentication;

public class JwtBearerAuthenticationDefaults : AuthenticationSchemeOptions
{
    public const string AuthenticationScheme = JwtBearerDefaults.AuthenticationScheme;
}