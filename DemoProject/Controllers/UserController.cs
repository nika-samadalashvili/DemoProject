using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DemoProject.Application.Phones.Commands.CreatePhone;
using DemoProject.Application.Users.Commands.CreateUser;
using DemoProject.Application.Users.Commands.DeleteUser;
using DemoProject.Application.Users.Queries.GetUser;
using DemoProject.Domain.Entities;

namespace DemoProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
        {
            await Mediator.Send(request);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand request)
        {
            await Mediator.Send(request);

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser(string phoneNumber)
        {
            var userName = await Mediator.Send(new GetUserQuery { PhoneNumber = phoneNumber });

            return Ok(new { userName });
        }
    }
}
