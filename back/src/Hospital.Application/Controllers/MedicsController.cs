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
using System;
using Hospital.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Hospital.Application.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class MedicsController : MainController
    {
        private readonly IMedicService _medicService;
        private readonly IMapper _mapper;

        public MedicsController(IMedicService medicService, IMapper mapper, INotificator notificator) : base(notificator)
        {
            _medicService = medicService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> Get()
        {
            var medics = await _medicService.ListAsync();
            return Ok(_mapper.Map<IEnumerable<Medic>, IEnumerable<MedicDTO>>(medics));
        }

        [HttpGet("{crm}")]
        public async Task<ActionResult<MedicDTO>> Get(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return NotFound();

            Medic medic;

            medic = await _medicService.FindByCrm(crm);

            return Ok(_mapper.Map<Medic, MedicDTO>(medic));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medic medic)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var _medic = await _medicService.SaveAsync<MedicValidator>(medic);

            if (_medic == null)
                return CustomResponse();

            var mappedMedic = _mapper.Map(medic, medic.GetType(), typeof(MedicDTO));

            return CreatedAtAction(nameof(Post), new { CRM = _medic.CRM }, _mapper.Map(medic, medic.GetType(), typeof(MedicDTO)));
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Medic medic)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            Medic updatedMedic = await _medicService.UpdateAsync<MedicValidator>(medic);

            if (updatedMedic == null)
                return CustomResponse();

            return Ok(_mapper.Map<Medic, MedicDTO>(updatedMedic));
            
        }

        [HttpDelete("{crm}")]
        public async Task<IActionResult> Delete(string crm)
        {

            if (string.IsNullOrEmpty(crm))
                return NotFound();

            Medic medicDeleted;

            medicDeleted = await _medicService.DeleteByCrmAsync(crm);

            if (medicDeleted == null)
                return CustomResponse(statusCode: StatusCodes.Status404NotFound);

            return Ok(_mapper.Map<Medic, MedicDTO>(medicDeleted));
        }
    }
}