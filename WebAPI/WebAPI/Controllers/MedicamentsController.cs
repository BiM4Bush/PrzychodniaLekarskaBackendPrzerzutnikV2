using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.PatientProfile;
using WebAPI.Services.PatientProfile;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private readonly IMedicamentService _medicamentService;

        public MedicamentsController(IMedicamentService medicamentService)
        {
            _medicamentService = medicamentService;
        }

        // GET: api/<MedicamentsController>
        [HttpGet]
        public async Task<IReadOnlyList<Medicament>> Get()
        {
            return await _medicamentService.Get();
        }

        // GET api/<MedicamentsController>/5
        [HttpGet("{id}")]
        public async Task<Medicament> Get(Guid id)
        {
            return await _medicamentService.Get(id);
        }

        // POST api/<MedicamentsController>
        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] Medicament medicament)
        {
            var medic = new Medicament()
            {
                Name = medicament.Name,
                Description = medicament.Description
            };

            try
            {
                var result = await _medicamentService.Add(medic);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<MedicamentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Medicament medicament)
        {
        }

        // DELETE api/<MedicamentsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _medicamentService.Delete(id);
        }
    }
}
