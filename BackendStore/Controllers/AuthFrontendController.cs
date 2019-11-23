using BackendStore.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackendStore.Controllers
{
    [EnableCors("http://localhost:4200", "*", "*")]
    [RoutePrefix("authfrontend")]
    public class AuthFrontendController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] User user)
        {
            return null;
        }

        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]User user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var exists = context.Users.Any(n => n.UserName == user.UserName);
                    if (exists) return BadRequest("Такий користувач вже існує");

                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(CreateToken(user));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public JwtPackage CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, user.UserName)
            });

            const string secretKey = "your secret key goes here";
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                subject: claims,
                signingCredentials: signinCredentials
                );

            var tokenString = tokenHandler.WriteToken(token);
            return new JwtPackage()
            {
                UserName = user.UserName,
                Token = tokenString
            };
        }


    }
}


