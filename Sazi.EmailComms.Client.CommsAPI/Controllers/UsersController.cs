using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazi.EmailComms.Core.Model;
using Sazi.EmailComms.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sazi.EmailComms.Client.CommsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;

        public UsersController(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userRepository.Get(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            _userRepository.Add(user);
            await _userRepository.Save();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task Put([FromBody] User user)
        {
            _userRepository.Update(user);
            await _userRepository.Save();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
            await _userRepository.Save();
        }
    }
}
