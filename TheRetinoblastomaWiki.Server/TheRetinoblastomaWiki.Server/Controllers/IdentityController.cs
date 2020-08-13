
namespace TheRetinoblastomaWiki.Server.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TheRetinoblastomaWiki.Server.Models.Identity;
    using Data.Models;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Options;
    using System.IdentityModel.Tokens.Jwt;
    using System;
    using System.Text;

    public abstract class IdentityController : ApiController
    {

        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;

        protected IdentityController(UserManager<User> userManager,
            IOptions<AppSettings> appSettings)
        { 
        this.userManager = userManager;
        this.appSettings = appSettings.Value;
        }
        // creating the register functionality
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
                
            };
            // returns the result , create the user with the password provided from the request
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        // creating the login functionality

        public async Task<ActionResult<string>> Login(LoginRequestModel model) 
        {
            // validation if user is logged in successfully

            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }
            //the logic behind creating the JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
