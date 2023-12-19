using IRC.Blazor.Services.Interfaces;
using IRC.DTOs.Employee;
using IRC.DTOs.EquipmentAssaignement;
using IRC.DTOs.Room;

namespace IRC.Blazor.Services
{
    public class EquipmentAssignementService : IEquipmentAssignementService
    {
        public List<GetEquipmentAssignementDTO> EquipmentAssignements { get; set; }
        public List<GetRoomDTO> Rooms { get; set; }
        public List<GetEmployeeDTO> Employees { get; set; }

        public Task CreateEquipmentAssignement(CreateEquipmentAssignementDTO createEquipmentAssignement)
        {
            throw new NotImplementedException();
        }

        public Task GetEmployee()
        {
            throw new NotImplementedException();
        }

        public Task GetEquipmentAssignement()
        {
            throw new NotImplementedException();
        }

        public Task GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task<GetEmployeeDTO> GetSingleEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<GetRoomDTO> GetSingleRoom()
        {
            throw new NotImplementedException();
        }
    }
}
