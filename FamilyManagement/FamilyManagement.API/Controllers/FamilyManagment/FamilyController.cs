using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using FamilyManagement.Services.Models.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{

    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService service;
        public FamilyController(IFamilyService service)
        {
            this.service = service;
        }

        // GET: api/<FamiliesController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var families = this.service.GetAllFamilies();

            return Ok(families);
        }

        // GET api/<FamiliesController>/5
        [HttpGet("familyById/{id}")]
        public IActionResult GetById(int id)
        {
            var family = this.service.GetFamilyById(id);

            if (family == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = family
            });
        }

        // POST api/<FamiliesController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] FamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var family = this.service.CreateFamily(model);

            var familyId = family.Id.ToString();

            return Created(familyId, family);
        }

        // PUT api/<FamiliesController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] FamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var family = this.service.EditFamily(model, id);
            if (family == null)
            {
                return NotFound(family);
            }

            return Ok(new
            {
                data = family
            });
        }

        // DELETE api/<FamiliesController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var family = this.service.DeleteFamily(id);

            return Ok(new
            {
                data = family
            });
        }
    }
}
