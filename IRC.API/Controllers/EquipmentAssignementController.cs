using AutoMapper;
using IRC.DTOs.EquipmentAssaignement;
using IRC.EFC;
using IRC.Models;
using Microsoft.AspNetCore.Mvc;

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

        public EquipmentAssignementController(ILogger<EquipmentAssignementController> logger, EquipmentAssignementEFC EquipmentAssignementEFC, IMapper mapper)
        {
            Logger = logger;
            this.EquipmentAssignementEFC = EquipmentAssignementEFC;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetEquipmentAssignementDTO>> GetEquipmentAssignement()
        {
            var ass = await EquipmentAssignementEFC.GetAllEquipmentAssignementsAsync();
            return Mapper.Map<List<GetEquipmentAssignementDTO>>(ass);
        }

        [HttpGet("{id}")]
        public async Task<string> GetAsync(int id)
        {
            EquipmentAssignement? EquipmentAssignement = await EquipmentAssignementEFC.GetEquipmentAssignementByIdAsync(id);

            return EquipmentAssignement.ToString();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] EquipmentAssignement EquipmentAssignement)
        {
            Logger.LogInformation($"Called {nameof(EquipmentAssignementEFC)}");
            await EquipmentAssignementEFC.AddEquipmentAssignementAsync(EquipmentAssignement);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] EquipmentAssignement EquipmentAssignement)
        {
            await EquipmentAssignementEFC.UpdateEquipmentAssignementAsync(EquipmentAssignement, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await EquipmentAssignementEFC.DeleteEquipmentAssignementAsync(id);
        }
    }
}
