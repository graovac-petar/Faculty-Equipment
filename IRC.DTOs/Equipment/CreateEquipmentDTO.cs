using IRC.Models;

namespace IRC.DTOs.Equipment
{
    public class CreateEquipmentDTO
    {
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public string? InventoryNumber { get; set; }
        public int? Quantity { get; set; }
        public EquipmentType? Type { get; set; }
    }
}
