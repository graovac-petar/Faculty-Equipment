using IRC.DTOs.Equipment;

namespace IRC.Blazor.Services.Interfaces
{
    public interface IEquipmentService
    {
        List<GetEquipmentDTO> Equipments { get; set; }
        Task GetEquipments();
        Task<GetEquipmentDTO> GetEquipment(int id);
        Task CreateEquipment(CreateEquipmentDTO createEquipmentDTO);
        Task DeleteEquipment(int id);
        Task UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO, int id);
    }
}
