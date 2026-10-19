using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<bool> CreateEmployeeAsync(CreateEmployeeDto model);
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto model);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}
