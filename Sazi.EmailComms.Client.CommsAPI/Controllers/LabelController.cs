using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sazi.EmailComms.Core.Model;
using Sazi.EmailComms.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Client.CommsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly IGenericRepository<Label> _labelRepository;

        public LabelController(IGenericRepository<Label> labelRepository)
        {
            _labelRepository = labelRepository;
        }

        // GET: api/<LabelController>
        [HttpGet]
        public async Task<IEnumerable<Label>> Get()
        {
            return await _labelRepository.GetAll();
        }

        // GET api/<Label>/5
        [HttpGet("{id}")]
        public async Task<Label> Get(Guid id)
        {
            return await _labelRepository.Get(id);
        }

        // POST api/<Label>
        [HttpPost]
        public async Task Post([FromBody] Label label)
        {
            _labelRepository.Add(label);
            await _labelRepository.Save();
        }

        // PUT api/<Label>/5
        [HttpPut]
        public async Task Put([FromBody] Label label)
        {
            _labelRepository.Update(label);
            await _labelRepository.Save();
        }

        // DELETE api/<Label>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _labelRepository.Delete(id);
            await _labelRepository.Save();
        }
    }
}

