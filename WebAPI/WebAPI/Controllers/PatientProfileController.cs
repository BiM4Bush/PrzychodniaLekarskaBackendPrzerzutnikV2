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
    public class PatientProfileController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientProfileController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/<PatientProfileController>
        [HttpGet]
        public async Task<IReadOnlyList<Patient>> Get()
        {
            return await _patientService.Get();
        }

        // GET api/<PatientProfileController>/5
        [HttpGet("{id}")]
        public async Task<Patient> Get(Guid id)
        {
            return await _patientService.Get(id);
        }

        // POST api/<PatientProfileController>
        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] Patient patient)
        {
            var Patient = new Patient()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Gender = patient.Gender,
                Adress = patient.Adress,
                PESEL = patient.PESEL
            };

            try
            {
                var result = await _patientService.Add(Patient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<PatientProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientProfileController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _patientService.Delete(id);
        }
    }
}
