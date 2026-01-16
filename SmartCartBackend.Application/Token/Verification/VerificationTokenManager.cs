using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartCardBackend.Application.Constants;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Token.Verification;

public class VerificationTokenManager(
    ILogger<VerificationTokenManager> logger, 
    IOptions<JwtOptions> options, 
    ISystemClock clock) 
    : TokenManager(logger, options, clock), IVerificationTokenManager
{
    public TokenResponse Generate(Session session, TimeSpan expirationPeriod)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.MobilePhone, session.Phone),
            new Claim(ClaimTypesConst.Purpose, TokenPurpose.Verification),
            new Claim(ClaimTypesConst.SessionId, session.Id.ToString()),
            new Claim(ClaimTypesConst.IpAddress, session.IpAddress),
            new Claim(ClaimTypesConst.UserAgent, session.UserAgent)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = Clock.Now + expirationPeriod;
        
        var securityToken = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            claims: claims,
            expires: expires.UtcDateTime,
            signingCredentials: credentials
        );
        
        var verificationToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return new TokenResponse { Token = verificationToken, ExpiresAt = expires.UtcDateTime };
    }
}