using AutoMapper;
using IRC.DTOs.Room;
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
        public IMapper Mapper { get; }

        public RoomController(ILogger<RoomController> logger, RoomEFC RoomEFC, IMapper mapper)
        {
            Logger = logger;
            this.RoomEFC = RoomEFC;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetRoomDTO>> GetRoom()
        {
            Logger.LogInformation($"Called {nameof(RoomEFC)}");
            var Mapped = await RoomEFC.GetAllRoomsAsync();
            return Mapper.Map<List<GetRoomDTO>>(Mapped);
        }

        [HttpGet("{id}")]
        public async Task<GetRoomDTO> GetAsync(int id)
        {
            Room? Room = await RoomEFC.GetRoomByIdAsync(id);
            return Mapper.Map<GetRoomDTO>(Room);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] CreateRoomDTO Room)
        {
            Logger.LogInformation($"Called {nameof(RoomEFC)}");
            var Mapped = Mapper.Map<Room>(Room);
            await RoomEFC.AddRoomAsync(Mapped);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateRoomDTO Room)
        {
            var Mapped = Mapper.Map<Room>(Room);
            await RoomEFC.UpdateRoomAsync(Mapped, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await RoomEFC.DeleteRoomAsync(id);
        }
    }
}
