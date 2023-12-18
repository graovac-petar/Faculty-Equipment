using AutoMapper;
using IRC.DTOs.Room;
using IRC.Models;

namespace IRC.API.Mapper
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, GetRoomDTO>().ReverseMap();
            CreateMap<Room, UpdateRoomDTO>().ReverseMap();
            CreateMap<Room, CreateRoomDTO>().ReverseMap();
        }
    }
}
