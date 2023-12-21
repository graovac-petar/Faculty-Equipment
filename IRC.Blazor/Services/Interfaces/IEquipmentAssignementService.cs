using IRC.DTOs.Employee;
using IRC.DTOs.EquipmentAssaignement;
using IRC.DTOs.Filter;
using IRC.DTOs.Room;

namespace IRC.Blazor.Services.Interfaces
{
    public interface IEquipmentAssignementService
    {
        List<GetEquipmentAssignementDTO> EquipmentAssignements { get; set; }
        List<GetRoomDTO> Rooms { get; set; }
        List<GetEmployeeDTO> Employees { get; set; }
        Task GetEmployee();
        Task GetRooms();
        Task CreateEquipmentAssignement(CreateEquipmentAssignementDTO createEquipmentAssignement);
        Task GetEquipmentAssignements();
        Task Filter(FilterRequestDTO filterRequest);

    }
}
