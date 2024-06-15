using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.UserManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // GET: api/<UsersController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var users = this.service.GetAllUsers();

            return Ok(users);
        }

        // GET api/<UsersController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = this.service.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = user
            });
        }

        

        // POST api/<UsersController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] UserModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var user = this.service.CreateUser(model);

            var userId = user.Id.ToString();

            return Created(userId, user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // PUT api/<UsersController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] UserModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
                /*
                List<string> errorsList = new List<string>();
                foreach(var error in ModelState.Values)
                {
                    //error.
                }
                return NotFound(new
                {
                    errors = errorsList,
                    value = new object()
                }); */
            }
            
            var user = this.service.EditUser(model, id);
            if (user == null)
            {
                return NotFound(user);
            }

            return Ok(new
            {
                data = user
            });
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // DELETE api/<UsersController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.service.DeleteUser(id);

            return Ok(new
            {
                data = user
            });
        }
    }
}
