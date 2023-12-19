using System.ComponentModel.DataAnnotations;

namespace IRC.Models
{
    public class Equipment
    {
        public const string TableName = "Equipment";
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string InventoryNumber { get; set; }
        public int? Quantity { get; set; }
        public EquipmentType Type { get; set; }
        public List<EquipmentAssignement> Assignments { get; set; } = new();
        public override string ToString()
        {
            return $"{EquipmentId}, {Name}, {SerialNumber}, {InventoryNumber}, {Quantity}";
        }
    }
}
