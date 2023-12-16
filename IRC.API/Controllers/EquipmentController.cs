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

        public EquipmentController(ILogger<EquipmentController> logger, EquipmentEFC equipmentEFC)
        {
            Logger = logger;
            EquipmentEFC = equipmentEFC;
        }

        [HttpGet]
        public async Task<List<Equipment>> GetEquipment()
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            return await EquipmentEFC.GetAllEquipmentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<string> GetAsync(int id)
        {
            Equipment? equipment = await EquipmentEFC.GetEquipmentByIdAsync(id);

            return equipment.ToString();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] Equipment equipment)
        {
            Logger.LogInformation($"Called {nameof(EquipmentEFC)}");
            await EquipmentEFC.AddEquipmentAsync(equipment);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Equipment equipment)
        {
            await EquipmentEFC.UpdateEquipmentAsync(equipment, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await EquipmentEFC.DeleteEquipmentAsync(id);
        }
    }
}
