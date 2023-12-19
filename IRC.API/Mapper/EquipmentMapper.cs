using AutoMapper;
using IRC.DTOs.Equipment;
using IRC.Models;

namespace IRC.API.Mapper
{
    public class EquipmenteMapper : Profile
    {
        public EquipmenteMapper()
        {
            CreateMap<Equipment, GetEquipmentDTO>().ReverseMap();
            CreateMap<Equipment, UpdateEquipmentDTO>().ReverseMap();
            CreateMap<Equipment, CreateEquipmentDTO>().ReverseMap();
            CreateMap<GetEquipmentDTO, CreateEquipmentDTO>().ReverseMap();
        }
    }
}
