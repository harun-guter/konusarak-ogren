using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Core.Helpers.Security;

public class JwtHelper : IAccessTokenHelper
{
    private DateTime _expires;

    public JwtHelper()
    {
        _expires = DateTime.Now.AddDays(7);
    }

    public JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signingCredentials) => new JwtSecurityToken(issuer: "issuer", audience: "audience", expires: _expires, notBefore: DateTime.Now, signingCredentials: signingCredentials);

    public AccessToken CreateAccessToken(User user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretpassword"));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwt = CreateJwtSecurityToken(user, signingCredentials);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken { Token = token, Expires = _expires };
    }
}

