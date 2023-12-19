using IRC.DTOs.Employee;
using IRC.DTOs.EquipmentAssaignement;
using IRC.DTOs.Room;

namespace IRC.Blazor.Services.Interfaces
{
    public interface IEquipmentAssignementService
    {
        List<GetEquipmentAssignementDTO> EquipmentAssignements { get; set; }
        List<GetRoomDTO> Rooms { get; set; }
        List<GetEmployeeDTO> Employees { get; set; }
        Task GetEquipmentAssignement();
        Task GetEmployee();
        Task GetRooms();
        Task<GetEmployeeDTO> GetSingleEmployee();
        Task<GetRoomDTO> GetSingleRoom();
        Task CreateEquipmentAssignement(CreateEquipmentAssignementDTO createEquipmentAssignement);


    }
}
