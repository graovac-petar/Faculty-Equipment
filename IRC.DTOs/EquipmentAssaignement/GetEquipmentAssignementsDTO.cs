using IRC.DTOs.Employee;
using IRC.DTOs.Equipment;
using IRC.DTOs.Room;

namespace IRC.DTOs.EquipmentAssaignement
{
    public class GetEquipmentAssignementDTO
    {
        public int? EquipmentAssignementId { get; set; }
        public int? EquipmentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public GetEquipmentDTO? Equipment { get; set; }
        public GetEmployeeDTO? Employee { get; set; }
        public GetRoomDTO? Room { get; set; }
    }
}
