
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace CraftIQ.Models
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> usermanager;

        public AuthService(UserManager<AppUser> usermanager)
        {
            this.usermanager = usermanager;
        }

        public async Task<AuthModel> Register(RegisterModel model)
        {
            if(await usermanager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email Is Exist" };

            if(await usermanager.FindByNameAsync(model.UserName) is not null)
                return new AuthModel { Message = "Name Is Exist" };

            AppUser user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash=model.Password
            };
            var result = await usermanager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new AuthModel { Message = "error" };

            var jwt = await CreateToken(user);

            return new AuthModel
            {
                IsAuthentecated=true,
                Token=new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpireOn=jwt.ValidTo,
                UserName=model.UserName,
                Email=model.Email,
            };
        }

        public async Task<AuthModel> GetToken(LoginModel model)
        {
            var authmodel = new AuthModel();
            var user = await usermanager.FindByEmailAsync(model.Email);
            if (user is null || !await usermanager.CheckPasswordAsync(user, model.Password))
            {
                authmodel.Message = "Incorrecrt Email Or Password";
                return authmodel;
            }

            var jwt = await CreateToken(user);
            authmodel.IsAuthentecated = true;
            authmodel.Token=new JwtSecurityTokenHandler().WriteToken(jwt);
            authmodel.ExpireOn=jwt.ValidTo;
            authmodel.UserName=model.UserName;
            authmodel.Email=model.Email;

            return authmodel;
        }

        private async Task<JwtSecurityToken> CreateToken(AppUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var roles = await usermanager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SecurityKey securitykey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes("zNnn59TLko0n6SBKWv6w0tvzTmYMcuak"));

            SigningCredentials signincred = new SigningCredentials
                (securitykey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:44374/",
                audience: "https://localhost:4200/",
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: signincred
                );

            return token;
        }
    }
}
