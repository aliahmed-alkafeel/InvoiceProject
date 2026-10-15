using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<bool> CreateEmployeeAsync(EmployeeDto model);
        Task<bool> UpdateEmployeeAsync(EmployeeDto model);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}
