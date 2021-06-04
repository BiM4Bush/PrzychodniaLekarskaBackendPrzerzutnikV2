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
                DoctorId = visit.DoctorId,
                Reason = visit.Reason,
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
        public async Task<OkObjectResult> Update(Guid id, [FromBody] MedicalVisitModel visit)
        {
            var data = await _medicalVisitService.Get(id);

            if (data != null)
            {
                data.Name = visit.Name;
                data.Surname = visit.Surname;
                data.PhoneNumber = visit.PhoneNumber;
                data.Date = visit.Date;
                data.Time = visit.Time;
                data.DoctorId = visit.DoctorId;
                data.Reason = visit.Reason;
                data.Confirmed = visit.Confirmed;
                data.DoctorRecommendation = visit.DoctorRecommendation;
            }
            var context = await _medicalVisitService.Update(data);
            return Ok(context);
        }

        // DELETE api/<MedicalVisitController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _medicalVisitService.Delete(id);
        }
    }
}
