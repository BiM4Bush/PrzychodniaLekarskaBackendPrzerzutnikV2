using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalVisitController : ControllerBase
    {
        private readonly IMedicalVisitService _medicalVisitService;

        public MedicalVisitController(IMedicalVisitService medicalVisitService)
        {
            _medicalVisitService = medicalVisitService;
        }

        // GET: api/<MedicalVisitController>
        [HttpGet]
        public async Task<IReadOnlyList<MedicalVisitModel>> Get()
        {
            return await _medicalVisitService.Get();
        }

        // GET api/<MedicalVisitController>/5
        [HttpGet("{id}")]
        public async Task<MedicalVisitModel> Get(Guid id)
        {
            return await _medicalVisitService.Get(id);
        }

        // POST api/<MedicalVisitController>
        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] MedicalVisitModel visit)
        {
            var medicalVisit = new MedicalVisitModel()
            {
                Name = visit.Name,
                Surname = visit.Surname,
                PhoneNumber = visit.PhoneNumber,
                Date = visit.Date,
                Time = visit.Time,
                Doctor = visit.Doctor,
                Private = visit.Private
            };

            try
            {
                var result = await _medicalVisitService.Add(medicalVisit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<MedicalVisitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicalVisitController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _medicalVisitService.Delete(id);
        }
    }
}
