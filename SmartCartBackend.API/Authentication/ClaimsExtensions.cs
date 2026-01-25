using System.Security.Claims;
using SmartCardBackend.Application.Constants;

namespace SmartCartBackend.API.Authentication;

public static class ClaimsExtensions
{
    public static ClaimsDto ToDto(this IEnumerable<Claim> claims)
    {
        var claimsList = claims.ToList();
        
        var phone = claimsList.Single(x => x.Type == ClaimTypes.MobilePhone).Value;
        var sessionId = Guid.Parse(claimsList.Single(x => x.Type == ClaimTypesConst.SessionId).Value);
        var purpose = claimsList.Single(x => x.Type == ClaimTypesConst.Purpose).Value;
        
        return new  ClaimsDto(phone, sessionId, purpose);
    }
}