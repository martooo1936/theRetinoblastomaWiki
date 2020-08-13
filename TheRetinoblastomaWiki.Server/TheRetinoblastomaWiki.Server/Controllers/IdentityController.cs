﻿
namespace TheRetinoblastomaWiki.Server.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TheRetinoblastomaWiki.Server.Models.Identity;
    using Data.Models;

    public abstract class IdentityController : ApiController
    {

        private readonly UserManager<User> userManager;
        public async Task<IActionResult> Register(RegisterUserRequestModel model)
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
    }
}
