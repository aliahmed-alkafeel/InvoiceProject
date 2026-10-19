using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(
                    nameof(unitOfWork),
                    "وحدة العمل مطلوبة.");
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employees
                .NoTrackingSelect()
                .Include(e => e.Group)
                .Where(e => e.Group != null && !e.Group.IsDeleted)
                .Select(emp => new EmployeeDto
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    PhoneNumber = emp.PhoneNumber,
                    EmployeeStartingDate = emp.EmployeeStartingDate.ToLocalTime(),
                    EmployeeEndingDate = emp.EmployeeEndingDate.HasValue
                        ? (DateTime?)emp.EmployeeEndingDate.Value.ToLocalTime()
                        : null,
                    Username = emp.Username,
                    Email = emp.Email,
                    GroupGuid = emp.GroupGuid,
                })
                .ToListAsync();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(
            Guid id)
        {
            var employee = await _unitOfWork.Employees
                .NoTrackingSelect()
                .Include(e => e.Group)
                .FirstOrDefaultAsync(e =>
                    e.Id == id &&
                    e.Group != null &&
                    !e.Group.IsDeleted);

            if (employee is null)
            {
                throw new InvalidOperationException(
                    "الموظف المطلوب غير موجود أو أن مجموعته غير متاحة.");
            }

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                EmployeeStartingDate = employee.EmployeeStartingDate,
                EmployeeEndingDate = employee.EmployeeEndingDate,
                Username = employee.Username,
                Email = employee.Email,
                GroupGuid = employee.GroupGuid,
            };
        }



        public async Task<bool> CreateEmployeeAsync(
            EmployeeDto model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(
                    nameof(model),
                    "بيانات الموظف مطلوبة.");
            }

            var isDuplicate = await _unitOfWork.Employees
                .NoTrackingSelect()
                .AnyAsync(e =>
                    e.Id != model.Id &&
                    !e.EmployeeEndingDate.HasValue &&
                    (e.Email == model.Email ||
                     e.Username == model.Username));

            if (isDuplicate)
                return false;

            var group = await _unitOfWork.Groups
                .NoTrackingSelect()
                .FirstOrDefaultAsync(g => g.Id == model.GroupGuid);

            if (group is null)
                return false;


            var employee = new Employee
            {
                Username = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeStartingDate = DateTime.UtcNow,
                PhoneNumber = model.PhoneNumber,
                GroupGuid = model.GroupGuid
            };

             _unitOfWork.Employees.Add(employee);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployeeAsync(
            EmployeeDto model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(
                    nameof(model),
                    "بيانات الموظف مطلوبة.");
            }

            var employee = await _unitOfWork.Employees
                .Select()
                .FirstOrDefaultAsync(e => e.Id == model.Id);

            if (employee is null)
            {
                throw new InvalidOperationException(
                    "الموظف المطلوب تعديله غير موجود.");
            }

            var isDuplicate = await _unitOfWork.Employees
                .NoTrackingSelect()
                .AnyAsync(e =>
                    e.Id != model.Id &&
                    (e.Email == model.Email ||
                     e.Username == model.Username));

            if (isDuplicate)
                return false;

            var group = await _unitOfWork.Groups
                .NoTrackingSelect()
                .FirstOrDefaultAsync(g => g.Id == model.GroupGuid);

            if (group is null)
                return false;


            employee.Username = model.Username;
            employee.Email = model.Email;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.EmployeeStartingDate = model.EmployeeStartingDate;
            employee.EmployeeEndingDate = model.EmployeeEndingDate;
            employee.PhoneNumber = model.PhoneNumber;
            employee.GroupGuid = model.GroupGuid;


            _unitOfWork.Employees.Update(employee);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> TerminateEmployeeAsync(Guid id)
        {
            var employee = await _unitOfWork.Employees
                .Select()
                .Include(e => e.Group)
                .FirstOrDefaultAsync(e =>
                    e.Id == id &&
                    e.Group != null &&
                    !e.Group.IsDeleted);

            if (employee is null)
                return false;

            if (employee.Group.GroupName ==
                InitUserGroup.Administrator.ToString())
            {
                return false;
            }

            if (employee.EmployeeEndingDate.HasValue)
                return false;

            employee.EmployeeEndingDate = DateTime.UtcNow;

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _unitOfWork.Employees
                .Select()
                .Include(e => e.Group)
                .FirstOrDefaultAsync(e =>
                    e.Id == id &&
                    e.Group != null &&
                    !e.Group.IsDeleted);

            if (employee is null)
                return false;

            if (employee.Group?.GroupName ==
                InitUserGroup.Administrator.ToString())
            {
                return false;
            }

            if (!employee.EmployeeEndingDate.HasValue)
            {
                employee.EmployeeEndingDate = DateTime.UtcNow;
            }

            _unitOfWork.Employees.Delete(employee);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}