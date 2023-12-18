using AutoMapper;
using IRC.DTOs.Equipment;
using IRC.EFC;
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
        public EquipmentEFC EquipmentEFC { get; }
        public IMapper Mapper { get; }

        public EquipmentController(ILogger<EquipmentController> logger, EquipmentEFC equipmentEFC, IMapper mapper)
        {
            Logger = logger;
            EquipmentEFC = equipmentEFC;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetEquipmentDTO>> GetEquipment()
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            var Equipments = await EquipmentEFC.GetAllEquipmentsAsync();
            return Mapper.Map<List<GetEquipmentDTO>>(Equipments);
        }

        [HttpGet("{id}")]
        public async Task<GetEquipmentDTO> GetAsync(int id)
        {
            Equipment? Equipment = await EquipmentEFC.GetEquipmentByIdAsync(id);
            return Mapper.Map<GetEquipmentDTO>(Equipment);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] CreateEquipmentDTO Equipment)
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            var Mapped = Mapper.Map<Equipment>(Equipment);
            await EquipmentEFC.AddEquipmentAsync(Mapped);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateEquipmentDTO Equipment)
        {
            var Mapped = Mapper.Map<Equipment>(Equipment);
            await EquipmentEFC.UpdateEquipmentAsync(Mapped, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await EquipmentEFC.DeleteEquipmentAsync(id);
        }
    }
}
