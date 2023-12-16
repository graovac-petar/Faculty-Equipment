using System.ComponentModel.DataAnnotations;

namespace IRC.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string RoomNumber { get; set; }
        public List<EquipmentAssignement> EquipmentAssignments { get; set; } = new();
        public override string ToString()
        {
            return $"{RoomNumber}";
        }
    }
}