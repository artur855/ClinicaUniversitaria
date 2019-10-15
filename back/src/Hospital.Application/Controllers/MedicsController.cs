using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using Hospital.Domain.DTO;
using Hospital.Service.Validators;

namespace Hospital.Application.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicsController : ControllerBase
    {
        private readonly IMedicService _medicService;
        private readonly IMapper _mapper;

        public MedicsController(IMedicService medicService, IMapper mapper)
        {
            _medicService = medicService;
            _mapper = mapper;
        }

        [EnableCors("MyPolicy")] 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> Get()
        {
            var medics = await _medicService.ListAsync();
            return Ok(_mapper.Map<IEnumerable<Medic>, IEnumerable<MedicDTO>>(medics));
        }

        [EnableCors("MyPolicy")] 
        [HttpGet("{crm}")]
        public async Task<ActionResult<MedicDTO>> Get(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return NotFound();

            Medic medic = await _medicService.FindByCrm(crm);

            return Ok(_mapper.Map<Medic, MedicDTO>(medic));
        }

        [EnableCors("MyPolicy")] 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medic medic)
        {
            var _medic = await _medicService.SaveAsync<MedicValidator>(medic);

            if (_medic == null)
                return BadRequest();

            var mappedMedic = _mapper.Map(medic, medic.GetType(), typeof(MedicDTO));

            return CreatedAtAction(nameof(Post), new { CRM = _medic.CRM }, _mapper.Map(medic, medic.GetType(), typeof(MedicDTO)));
        }
        
        [EnableCors("MyPolicy")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Medic medic)
        {
            if (medic == null)
                return BadRequest();

            Medic updatedMedic = await _medicService.UpdateAsync<MedicValidator>(medic);

            if (updatedMedic == null)
                return NoContent();

            return Ok(_mapper.Map<Medic, MedicDTO>(updatedMedic));
            
        }

        [EnableCors("MyPolicy")] 
        [HttpDelete("{crm}")]
        public async Task<IActionResult> Delete(string crm)
        {

            if (string.IsNullOrEmpty(crm))
                return NotFound();

            var medicDeleted = await _medicService.DeleteByCrmAsync(crm);

            return Ok(_mapper.Map<Medic, MedicDTO>(medicDeleted));
        }
    }
}