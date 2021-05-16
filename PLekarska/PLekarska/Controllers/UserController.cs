using Microsoft.AspNetCore.Mvc;
using PLekarska.Core;
using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PLekarska.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IReadOnlyList<User>> Get()
        {
            return await _userService.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userService.Get(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await _userService.Add(user);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            await _userService.Delete(id);
        }
    }
}
