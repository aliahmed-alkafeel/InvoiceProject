using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
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

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync(CancellationToken cts)
        {
            var employees = await _unitOfWork.Employees
                .NoTrackingSelect()
                .Include(e => e.Group)
                .Where(e => e.Group != null && !e.Group.IsDeleted)
                .ToListAsync(cts);

            return employees.Select(e => ToDto(e)).ToList();
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

            return ToDto(employee);
        }

        private static EmployeeDto ToDto(Employee employee)
        {
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
                Group = employee.Group == null ? null : new GroupDto
                {
                    Id = employee.Group.Id,
                    GroupName = employee.Group.GroupName
                },
            };
        }



        public async Task<bool> CreateEmployeeAsync(
            CreateEmployeeDto model)
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
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                EmployeeStartingDate = model.EmployeeStartingDate.Date,
                EmployeeEndingDate = model.EmployeeEndingDate?.Date,
                PhoneNumber = model.PhoneNumber,
                GroupGuid = model.GroupGuid
            };

             _unitOfWork.Employees.Add(employee);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployeeAsync(
            UpdateEmployeeDto model)
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
            employee.EmployeeStartingDate = model.EmployeeStartingDate.Date;
            employee.EmployeeEndingDate = model.EmployeeEndingDate?.Date;
            employee.PhoneNumber = model.PhoneNumber;
            employee.GroupGuid = model.GroupGuid;

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                employee.Password = model.Password;
            }


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
                InitUserGroup.Administrator)
            {
                return false;
            }

            if (employee.EmployeeEndingDate.HasValue)
                return false;

            employee.EmployeeEndingDate = DateTime.Now.Date;

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
                InitUserGroup.Administrator)
            {
                return false;
            }

            if (!employee.EmployeeEndingDate.HasValue)
            {
                employee.EmployeeEndingDate = DateTime.Now.Date;
            }

            _unitOfWork.Employees.Delete(employee);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}