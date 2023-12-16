using AutoMapper;
using IRC.DTOs.Room;

namespace IRC.API.Mapper
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<RoomMapper, GetRoomDTO>().ReverseMap();
        }
    }
}
