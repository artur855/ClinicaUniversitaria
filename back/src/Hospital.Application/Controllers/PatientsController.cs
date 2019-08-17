using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            return Ok(await _patientService.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            if(id==null)
                return NotFound();

            return Ok(await _patientService.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();
            var newPatient = await _patientService.Save(patient);
            return CreatedAtAction(nameof(Post), new {id = newPatient.Id}, newPatient);
        }

        [HttpPut]
        public async Task<ActionResult<Patient>> Put([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();
            var newPatient = await _patientService.Update(patient);
            return Ok(newPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _patientService.Delete(id);
            return Ok();
        }
    }
}