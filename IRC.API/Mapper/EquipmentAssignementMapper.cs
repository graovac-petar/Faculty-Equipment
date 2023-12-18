using AutoMapper;
using IRC.DTOs.EquipmentAssaignement;
using IRC.Models;

namespace IRC.API.Mapper
{
    public class EquipmentAssignementMapper : Profile
    {
        public EquipmentAssignementMapper()
        {
            CreateMap<EquipmentAssignement, GetEquipmentAssignementDTO>().ReverseMap();
            CreateMap<EquipmentAssignement, UpdateEquipmentAssignementDTO>().ReverseMap();
            CreateMap<EquipmentAssignement, CreateEquipmentAssignementDTO>().ReverseMap();
        }
    }
}
