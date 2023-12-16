using AutoMapper;
using IRC.DTOs.Employee;
using IRC.Models;

namespace IRC.API.Mapper
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, GetEmployeeDTO>()
                .ReverseMap();
        }
    }
}
