using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.Doctor;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IReadOnlyList<DoctorModel>> Get()
        {
            return await _doctorService.Get();
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<DoctorModel> Get(Guid id)
        {
            return await _doctorService.Get(id);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] DoctorModel doctor)
        {
            var Doctor = new DoctorModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                MedicalSpecialization = doctor.MedicalSpecialization
            };

            try
            {
                var result = await _doctorService.Add(Doctor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _doctorService.Delete(id);
        }
    }
}
