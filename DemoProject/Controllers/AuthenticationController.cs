using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoProject.Application.Common.Interfaces;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private IIdentityService _identityService;

        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var token = await _identityService.LoginAsync(userName, password);

            return Ok(token);
        }
    }
}
