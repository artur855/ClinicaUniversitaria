using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace Hospital.Application.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicsController : ControllerBase
    {
        private readonly IMedicService _medicService;

        public MedicsController(IMedicService medicService)
        {
            _medicService = medicService;
        }

        [EnableCors("MyPolicy")] 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> Get()
        {
            return Ok(await _medicService.ListAsync());
        }

        [EnableCors("MyPolicy")] 
        [HttpGet("{crm}")]
        public async Task<ActionResult<Medic>> Get(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return NotFound();

            return await _medicService.FindByCrm(crm);
        }

        [EnableCors("MyPolicy")] 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medic medic)
        {
            var _medic = await _medicService.SaveAsync(medic);

            if (_medic == null)
                return BadRequest();

            return CreatedAtAction(nameof(Post), new { CRM = _medic.CRM }, medic);
        }

        [EnableCors("MyPolicy")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Medic medic)
        {
            if (medic == null)
                return BadRequest();

            Medic updatedMedic = await _medicService.UpdateAsync(medic);

            if (updatedMedic == null)
                return NoContent();

            return Ok(medic);
            
        }

        [EnableCors("MyPolicy")] 
        [HttpDelete("{crm}")]
        public async Task<IActionResult> Delete(string crm)
        {

            if (string.IsNullOrEmpty(crm))
                return NotFound();

            await _medicService.DeleteAsync(crm);

            return NoContent();
        }
    }
}