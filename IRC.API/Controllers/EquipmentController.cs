using AutoMapper;
using IRC.DTOs.Equipment;
using IRC.EFC.Interfaces;
using IRC.EFC.Validators;
using IRC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRC.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        public ILogger<EquipmentController> Logger { get; }
        public IEquipmentEFC EquipmentEFC { get; }
        public IMapper Mapper { get; }
        public EquipmentValidator _validator { get; }

        public EquipmentController(ILogger<EquipmentController> logger, IEquipmentEFC equipmentEFC, IMapper mapper, EquipmentValidator validations)
        {
            Logger = logger;
            EquipmentEFC = equipmentEFC;
            Mapper = mapper;
            _validator = validations;
        }

        [HttpGet("all")]
        public async Task<List<GetEquipmentDTO>> GetEquipment()
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            var Equipments = await EquipmentEFC.GetAllEquipmentsAsync();
            return Mapper.Map<List<GetEquipmentDTO>>(Equipments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEquipmentDTO>> GetAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Equipment? Equipment = await EquipmentEFC.GetEquipmentByIdAsync(id);
            var validationResult = await _validator.ValidateAsync(Equipment);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            return Ok(Mapper.Map<GetEquipmentDTO>(Equipment));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateEquipmentDTO Equipment)
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            var Mapped = Mapper.Map<Equipment>(Equipment);
            var validationResult = await _validator.ValidateAsync(Mapped);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            await EquipmentEFC.AddEquipmentAsync(Mapped);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UpdateEquipmentDTO Equipment)
        {
            var Mapped = Mapper.Map<Equipment>(Equipment);
            var validationResult = await _validator.ValidateAsync(Mapped);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            await EquipmentEFC.UpdateEquipmentAsync(Mapped, id);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (await EquipmentEFC.DeleteEquipmentAsync(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
