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
        // GET: api/<ValuesController>
        [HttpGet]
        public Task<List<Equipment>> GetEquipment()
        {
            Logger.LogInformation("INFO");
            throw new NotImplementedException();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
