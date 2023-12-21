using AutoMapper;
using IRC.DTOs.EquipmentAssaignement;
using IRC.DTOs.Filter;
using IRC.EFC;
using IRC.EFC.Validators;
using IRC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRC.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentAssignementController : ControllerBase
    {
        public ILogger<EquipmentAssignementController> Logger { get; }
        public EquipmentAssignementEFC EquipmentAssignementEFC { get; }
        public IMapper Mapper { get; }
        public EquipmentAssignementValidator _validator { get; }

        public EquipmentAssignementController(ILogger<EquipmentAssignementController> logger, EquipmentAssignementEFC EquipmentAssignementEFC, IMapper mapper, EquipmentAssignementValidator validations)
        {
            Logger = logger;
            this.EquipmentAssignementEFC = EquipmentAssignementEFC;
            Mapper = mapper;
            _validator = validations;
        }

        [HttpGet]
        public async Task<List<GetEquipmentAssignementDTO>> GetEquipmentAssignement()
        {
            var ass = await EquipmentAssignementEFC.GetAllEquipmentAssignementsAsync();
            var Mapr = Mapper.Map<List<GetEquipmentAssignementDTO>>(ass);
            return Mapr;
        }

        [HttpGet("{id}")]
        public async Task<GetEquipmentAssignementDTO> GetAsync(int id)
        {

            EquipmentAssignement? EquipmentAssignement = await EquipmentAssignementEFC.GetEquipmentAssignementByIdAsync(id);

            return Mapper.Map<GetEquipmentAssignementDTO>(EquipmentAssignement);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateEquipmentAssignementDTO EquipmentAssignement)
        {
            Logger.LogInformation($"Called {nameof(EquipmentAssignementEFC)}");
            var Map = Mapper.Map<EquipmentAssignement>(EquipmentAssignement);

            var validationResult = await _validator.ValidateAsync(Map);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            await EquipmentAssignementEFC.AddEquipmentAssignementAsync(Map);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateEquipmentAssignementDTO EquipmentAssignement)
        {
            var Map = Mapper.Map<EquipmentAssignement>(EquipmentAssignement);
            await EquipmentAssignementEFC.UpdateEquipmentAssignementAsync(Map, id);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await EquipmentAssignementEFC.DeleteEquipmentAssignementAsync(id);
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<GetEquipmentAssignementDTO>>> SearchEquipmentAssignment([FromBody] FilterRequestDTO filterModel)
        {
            var model = await Mapper.ProjectTo<GetEquipmentAssignementDTO>(EquipmentAssignementEFC.Search(filterModel)).ToListAsync();
            return Ok(model);
        }

    }
}
