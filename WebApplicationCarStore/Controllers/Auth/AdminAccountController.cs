using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationCarStore.Auth;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Controllers.Auth
{
    public class AdminAccountController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<MyIdentityUser> passwordHasher;


        public AdminAccountController(ApplicationDbContext context)
        {
            _context = context;
            passwordHasher = new PasswordHasher<MyIdentityUser>(null);

        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = _context.Users.FirstOrDefault(x => x.UserName == username && x.PasswordHash == password);

            MyIdentityUser identityUser = null;
            var users= _context.Users.Where(user => user.UserName == username);

            foreach (var user in users)
            {
                if (user.UserName == username && passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
                {
                    identityUser = user;
                    break;
                }
            }

            if (identityUser == null)
                return null;

            var claims = new List<Claim>
            {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, identityUser.UserName),
                 new Claim(ClaimsIdentity.DefaultNameClaimType, "admin")
            };


            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);


            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        }
    
    }
}
