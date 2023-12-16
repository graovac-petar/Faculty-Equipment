using IRC.EFC;
using IRC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IRC.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        public ILogger<RoomController> Logger { get; }
        public RoomEFC RoomEFC { get; }

        public RoomController(ILogger<RoomController> logger, RoomEFC RoomEFC)
        {
            Logger = logger;
            this.RoomEFC = RoomEFC;
        }

        [HttpGet]
        public async Task<List<Room>> GetRoom()
        {
            Logger.LogInformation($"Called {nameof(RoomEFC)}");
            return await RoomEFC.GetAllRoomsAsync();
        }

        [HttpGet("{id}")]
        public async Task<string> GetAsync(int id)
        {
            Room? Room = await RoomEFC.GetRoomByIdAsync(id);

            return Room.ToString();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] Room Room)
        {
            Logger.LogInformation($"Called {nameof(RoomEFC)}");
            await RoomEFC.AddRoomAsync(Room);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Room Room)
        {
            await RoomEFC.UpdateRoomAsync(Room, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await RoomEFC.DeleteRoomAsync(id);
        }
    }
}
