using System.ComponentModel.DataAnnotations;

namespace IRC.Models
{
    public class Employee
    {
        public const string TableName = "Employee";
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Department { get; set; }
        public List<EquipmentAssignement> AssignedEquipment { get; set; }
    }
}
