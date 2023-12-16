using IRC.DTOs.Employee;
using IRC.DTOs.Equipment;
using IRC.DTOs.Room;

namespace IRC.DTOs.EquipmentAssaignement
{
    public class GetEquipmentAssignementDTO
    {
        public const string TableName = "EquipmentAssignment";
        public int EquipmentAssignementId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public GetEquipmentDTO Equipment { get; set; }
        public GetEmployeeDTO Employee { get; set; }
        public GetRoomDTO Room { get; set; }
        public override string ToString()
        {
            return $"{EquipmentAssignementId},{Equipment}, {Employee},{Room},{DateBorrowed}";
        }
    }
}
