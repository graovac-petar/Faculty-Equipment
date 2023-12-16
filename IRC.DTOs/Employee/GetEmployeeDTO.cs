namespace IRC.DTOs.Employee
{
    public class GetEmployeeDTO
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public override string ToString()
        {
            return $"{EmployeeId}, {Name}, {Department} ";
        }
    }
}
