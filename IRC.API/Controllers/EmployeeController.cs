using AutoMapper;
using IRC.DTOs.Employee;
using IRC.EFC;
using IRC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRC.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public ILogger<EmployeeController> Logger { get; }
        public EmployeeEFC EmployeeEFC { get; }
        public IMapper Mapper { get; }

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeEFC EmployeeEFC, IMapper mapper)
        {
            Logger = logger;
            this.EmployeeEFC = EmployeeEFC;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetEmployeeDTO>> GetEmployee()
        {
            Logger.LogInformation($"Called {nameof(EmployeeEFC)}");
            var employees = await EmployeeEFC.GetAllEmployeesAsync();
            return Mapper.Map<List<GetEmployeeDTO>>(employees);
        }

        [HttpGet("{id}")]
        public async Task<GetEmployeeDTO> GetAsync(int id)
        {
            Employee? Employee = await EmployeeEFC.GetEmployeeByIdAsync(id);
            return Mapper.Map<GetEmployeeDTO>(Employee);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] CreateEmployeeDTO Employee)
        {
            Logger.LogInformation($"Called {nameof(EmployeeEFC)}");
            var Mapped = Mapper.Map<Employee>(Employee);
            await EmployeeEFC.AddEmployeeAsync(Mapped);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateEmployeeDTO Employee)
        {
            var Mapped = Mapper.Map<Employee>(Employee);
            await EmployeeEFC.UpdateEmployeeAsync(Mapped, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await EmployeeEFC.DeleteEmployeeAsync(id);
        }
    }
}
