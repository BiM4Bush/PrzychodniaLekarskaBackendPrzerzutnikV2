using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;
using WebAPI.Services.PatientProfile;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseasesController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        // GET: api/<DiseasesController>
        [HttpGet]
        public async Task<IReadOnlyList<Disease>> Get()
        {
            return await _diseaseService.Get();
        }

        // GET api/<DiseasesController>/5
        [HttpGet("{id}")]
        public async Task<Disease> Get(Guid id)
        {
            return await _diseaseService.Get(id);
        }

        // POST api/<DiseasesController>
        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] Disease disease)
        {
            var dis = new Disease()
            {
                Name = disease.Name,
                Symptoms = disease.Symptoms,
                Cure = disease.Cure
            };

            try
            {
                var result = await _diseaseService.Add(dis);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<DiseasesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Disease disease)
        {
        }

        // DELETE api/<DiseasesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _diseaseService.Delete(id);
        }
    }
}
