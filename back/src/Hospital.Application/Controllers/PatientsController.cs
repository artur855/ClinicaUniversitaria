using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Domain.Command;
using Hospital.Domain.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            var patients = await _patientService.ListAsync();
            return Ok(_mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDTO>>(patients));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            if(id<=0)
                return NotFound();

            Patient patient = await _patientService.FindByIdAsync(id);

            return Ok(_mapper.Map<Patient, PatientDTO>(patient));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientCommand patientCommand)
        {
            Patient patient = _mapper.Map<PatientCommand, Patient>(patientCommand);

            if (patient == null)
                return BadRequest();
            var newPatient = await _patientService.SaveAsync<PatientValidator>(patient);
            return CreatedAtAction(nameof(Post), new {id = newPatient.Id}, _mapper.Map<Patient, PatientDTO>(newPatient));
        }

        [HttpPut]
        public async Task<ActionResult<Patient>> Put([FromBody] PatientCommand patientCommand)
        {
            Patient patient = _mapper.Map<PatientCommand, Patient>(patientCommand);

            if (patient == null)
                return BadRequest();
            var newPatient = await _patientService.UpdateAsync<PatientValidator>(patient);
            return Ok(_mapper.Map<Patient, PatientDTO>(newPatient));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _patientService.DeleteAsync(id);
            return Ok();
        }
    }
}