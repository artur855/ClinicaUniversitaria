using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Application.Command;
using Hospital.Application.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class PatientsController : MainController
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper, INotificator notificator) : base(notificator)
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
            if(id <= 0)
                return NotFound();

            Patient patient = await _patientService.FindByIdAsync(id);

            if (patient == null)
                return NoContent(); 

            return Ok(_mapper.Map<Patient, PatientDTO>(patient));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientCommand patientCommand)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            Patient patient = _mapper.Map<PatientCommand, Patient>(patientCommand);

            var newPatient = await _patientService.SaveAsync<PatientValidator>(patient);

            if (newPatient == null)
                return CustomResponse();

            return CreatedAtAction(nameof(Post), new {id = newPatient.Id}, _mapper.Map<Patient, PatientDTO>(newPatient));
        }

        [HttpPut]
        public async Task<ActionResult<Patient>> Put([FromBody] PatientCommand patientCommand)
        {

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            Patient patient = _mapper.Map<PatientCommand, Patient>(patientCommand);

            var newPatient = await _patientService.UpdateAsync<PatientValidator>(patient);

            if (newPatient == null)
                return CustomResponse();

            return Ok(_mapper.Map<Patient, PatientDTO>(newPatient));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var patient = await _patientService.DeleteAsync(id);

            if (patient == null)
                return CustomResponse(StatusCodes.Status404NotFound);

            return Ok();
        }
    }
}