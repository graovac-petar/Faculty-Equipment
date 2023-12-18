namespace IRC.DTOs.EquipmentAssaignement
{
    public class CreateEquipmentAssignementDTO
    {
        public int? EquipmentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? DateBorrowed { get; set; }
    }
}
