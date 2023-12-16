using IRC.Models;

namespace IRC.DTOs.Equipment
{
    public class GetEquipmentDTO
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }

        public int? Quantity { get; set; }

        public EquipmentType? Type { get; set; }

        public override string ToString()
        {
            return $"{EquipmentId}, {Name}, {SerialNumber}, {InventoryNumber}, {Quantity}";
        }
    }
}
