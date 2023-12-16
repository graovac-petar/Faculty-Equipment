using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRC.Models
{
    public class EquipmentAssignement
    {
        public const string TableName = "EquipmentAssignment";
        [Key]
        public int EquipmentAssignementId { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public Equipment Equipment { get; set; }
        public Employee Employee { get; set; }
        public Room Room { get; set; }
        public override string ToString()
        {
            return $"{EquipmentAssignementId},{EquipmentId}, {EmployeeId},{RoomId},{DateBorrowed}";
        }
    }
}