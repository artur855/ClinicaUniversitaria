using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infra.Data.Context;
using Hospital.Service.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly IMedicService _medicService;

        public MedicsController(IMedicService medicService)
        {
            _medicService = medicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> Get()
        {
            return Ok(await _medicService.ListAsync());
        }

        [HttpGet("{crm}")]
        public async Task<ActionResult<Medic>> Get(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return NotFound();

            return await _medicService.FindByCrm(crm);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medic medic)
        {
            var _medic = await _medicService.SaveAsync(medic);

            if (_medic == null)
                return BadRequest();

            return CreatedAtAction(nameof(Post), new { CRM = _medic.CRM }, medic);
        }
        
        [HttpPut("{crm}")]
        public async Task<IActionResult> Put(string crm, [FromBody] Medic medic)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return BadRequest();

            await _medicService.UpdateAsync(crm, medic);

            return NoContent();
            
        }

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