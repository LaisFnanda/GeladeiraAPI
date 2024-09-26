using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace Services.ServicesClasses
{
    public class LoginService: ILoginService
    {
        private readonly string? _key;

        IConfiguration configuration;
        public LoginService(IConfiguration config)
        {
            _key = config.GetValue<string>("Key");
            configuration = config;
        }  

        public string GenerateJwtToken (string username)
        {
            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub, username),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (_key != null)
            {

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creads);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return string.Empty;
        }
    }
}
