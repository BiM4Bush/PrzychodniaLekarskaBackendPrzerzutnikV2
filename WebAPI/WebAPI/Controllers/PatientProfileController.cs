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
                telNumber = patient.telNumber,
                birthdayDate = patient.birthdayDate,
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
        public async Task<OkObjectResult> PutAsync([FromRoute]Guid id, [FromBody] Patient patient)
        {
            var data = await _patientService.Get(id);

            if ( data != null)
            {
                data.Name = patient.Name;
                data.Surname = patient.Surname;
                data.Gender = patient.Gender;
                data.telNumber = patient.telNumber;
                data.birthdayDate = patient.birthdayDate;
                data.Adress = patient.Adress;
                data.PESEL = patient.PESEL;
            }
            var context = await _patientService.Update(data);
            return Ok(context);
        }

        // DELETE api/<PatientProfileController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _patientService.Delete(id);
        }
    }
}
