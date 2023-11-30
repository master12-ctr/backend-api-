
using FirstProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace FirstProject.Repository
{
 public class JWTServiceManage : IJWTTokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly UsersdbContext _dbcontext;

        public JWTServiceManage(IConfiguration configuration, UsersdbContext dbContext)
        {
            _configuration = configuration;
            _dbcontext = dbContext;
        }
        public JWTTokens Authenticate(User users)
        {
    
            if (!_dbcontext.User.Any(e => e.UserName == users.UserName && e.Password == users.Password))
            {
                return null;            
            }

            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(_configuration["JWTToken:key"]);
            var ToeknDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var toekn = tokenhandler.CreateToken(ToeknDescp);

            return new JWTTokens { Token = tokenhandler.WriteToken(toekn) };

        }

    }
}