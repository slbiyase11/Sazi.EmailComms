using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazi.EmailComms.Core.DomainServices;
using Sazi.EmailComms.Core.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sazi.EmailComms.Client.CommsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IIdentityService _identityService;

        public EmailController(IEmailService emailService, IIdentityService identityService)
        {
            _emailService = emailService;
            _identityService = identityService;
        }

        // POST api/<EmailController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Email email)
        {          
            var results = await _emailService.SendEmail(email);
            return results;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Email>> Get(Guid userId)
        {
            return await _emailService.GetEmail(userId);
        }
        [HttpGet("search/{search}")]
        public async Task<IEnumerable<Email>> Search(string search)
        {
            return await _emailService.SearchEmails(search);
        }

        [HttpPut]
        public async Task Put([FromBody] Email email)
        {
            await _emailService.UpdateEmail(email);
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _emailService.DeleteEmail(id);
        }
    } 
}
