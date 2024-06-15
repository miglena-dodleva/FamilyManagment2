using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserToFamilyController : ControllerBase
    {
        private readonly IUserToFamilyService service;

        public UserToFamilyController(IUserToFamilyService service)
        {
            this.service = service;
        }

        // GET: api/<UserToFamilyController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var userToFamilies = this.service.GetAllUserToFamilies();
            
            return Ok(userToFamilies);
        }

        // GET api/<UserToFamilyController>/5
        [HttpGet("userToFamilyById/{id}")]
        public IActionResult GetById(int id)
        {
            var userToFamily = this.service.GetUserToFamilyById(id);

            if (userToFamily == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = userToFamily
            });
        }

        // POST api/<UserToFamilyController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] UserToFamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var userToFamily = this.service.CreateUserToFamily(model);

            var id = userToFamily.Id.ToString();

            return Created(id, userToFamily);
        }

        // PUT api/<UserToFamilyController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] UserToFamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var userToFamily = this.service.EditUserToFamily(model, id);
            if (userToFamily == null)
            {
                return NotFound(userToFamily);
            }

            return Ok(new
            {
                data = userToFamily
            });
        }

        // DELETE api/<UserToFamilyController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var userToFamily = this.service.DeleteUserToFamily(id);

            return Ok(new
            {
                data = userToFamily
            });
        }
    }
}
