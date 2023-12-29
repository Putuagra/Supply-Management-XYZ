using System.Security.Claims;

namespace Supply_Management_XYZ.Server.Contracts;

public interface ITokenHandler
{
    string GenerateToken(IEnumerable<Claim> claims);
}
