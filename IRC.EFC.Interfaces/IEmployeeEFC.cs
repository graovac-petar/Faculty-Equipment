using IRC.Models;

namespace IRC.EFC.Interfaces
{
    public interface IEmployeeEFC
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(Employee employee);

        Task DeleteEmployeeAsync(int id);
        Task<bool> CheckExistAsync(int id);
        Task UpdateEmployeeAsync(Employee employee, int id);
    }
}
