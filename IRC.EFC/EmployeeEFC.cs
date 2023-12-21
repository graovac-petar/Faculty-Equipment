using IRC.EFC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC
{
    public class EmployeeEFC : IEmployeeEFC
    {
        public EmployeeEFC(DBContext context)
        {
            Context = context;
        }

        public DBContext Context { get; }

        public async Task AddEmployeeAsync(Models.Employee employee)
        {
            await Context.Employee.AddAsync(employee);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await Context.Employee.AnyAsync(x => x.EmployeeId == id);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (await CheckExistAsync(id))
            {
                var employee = await GetEmployeeByIdAsync(id);
                Context.Employee.Remove(employee);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Employee>> GetAllEmployeesAsync()
        {
            var uniqueEmployee = await Context.Employee
                                   .GroupBy(room => room.Name)
                                   .Select(group => group.First())
                                   .ToListAsync();

            return uniqueEmployee;
        }

        public async Task<Models.Employee?> GetEmployeeByIdAsync(int id)
        {
            return await Context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task UpdateEmployeeAsync(Models.Employee employee, int id)
        {
            var existingEmployee = await Context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (existingEmployee == null)
                return;

            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;


            await Context.SaveChangesAsync();
        }
    }
}
