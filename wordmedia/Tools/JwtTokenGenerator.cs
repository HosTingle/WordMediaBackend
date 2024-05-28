using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wordmedia.Tools;

namespace SweapCard.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims= new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.role))
                claims.Add(new Claim(ClaimTypes.Role, model.role));

            claims.Add(new Claim("UserId", model.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(model.username))
            {
                claims.Add(new Claim("Username",model.username));
     
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.key));
            var signinCredentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
