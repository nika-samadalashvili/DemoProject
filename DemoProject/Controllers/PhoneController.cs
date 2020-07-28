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
using DemoProject.Application.Phones.Commands.DeletePhone;
using DemoProject.Application.Phones.Queries.GetPhones;
using DemoProject.Domain.Entities;

namespace DemoProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PhoneController : ApiController
    {

        private readonly UserManager<ApplicationUser> _userManager;
        
        public PhoneController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPhone(string phoneNumber)
        {
            var id = HttpContext.User.Claims.FirstOrDefault(o => o.Type == "id").Value;

            var resultId = await Mediator.Send(new CreatePhoneCommand
            {
                ApplicationUserId = id,
                PhoneNumber = phoneNumber
            });

            return CreatedAtAction(nameof(AddPhone), new { id = resultId });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPhones()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(o => o.Type == "id").Value;

            var phones = await Mediator.Send(new GetPhonesQuery
            {
                ApplicaitonUserId = id
            });

            return Ok(phones);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePhone(string phoneNumber)
        {
            await Mediator.Send(new DeletePhoneCommand { PhoneNumber = phoneNumber });

            return NoContent();
        }
    }
}
