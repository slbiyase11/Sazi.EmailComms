using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sazi.EmailComms.Core.DomainServices;
using Sazi.EmailComms.Core.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Client.CommsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public SecurityController( IIdentityService identityService)
        {
            
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if(string.IsNullOrEmpty(Request.Headers["ClientId"]) || string.IsNullOrEmpty(Request.Headers["ClientSecret"]))
                return BadRequest();

            var authToken = await _identityService.GetAccessToken(Request.Headers["ClientId"], Request.Headers["ClientSecret"]);         
            return Ok(authToken);
        }
    }
}
