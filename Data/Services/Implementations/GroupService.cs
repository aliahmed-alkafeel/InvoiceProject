using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.Dashboard.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(
                    nameof(unitOfWork),
                    "وحدة العمل مطلوبة.");
        }

        public async Task<bool> CreateGroupAsync(CreateGroupDto model)
        {
            if (model is null)
                throw new ArgumentNullException(
                    nameof(model),
                    "بيانات المجموعة مطلوبة.");

            if (string.IsNullOrWhiteSpace(model.GroupName))
                throw new ArgumentException("اسم المجموعة مطلوب");

            var hasRepeatedName = await _unitOfWork.Groups
                .Select()
                .AnyAsync(g => g.GroupName == model.GroupName);

            if (hasRepeatedName)
                return false;

            var roleIds = model.GroupRoles
                .Select(gr => gr.RoleGuid)
                .Distinct()
                .ToList();

            var roles = await _unitOfWork.Roles
                .Select()
                .Where(r => roleIds.Contains(r.Id))
                .ToListAsync();
            var group = new Group
            {
                Id = Guid.NewGuid(),
                GroupName = model.GroupName,
                Notes = model.Notes
            };

            foreach (var role in roles)
            {
                group.GroupRoles.Add(new GroupRole
                {
                    GroupGuid = group.Id,
                    RoleGuid = role.Id
                });
            }

            _unitOfWork.Groups.Add(group);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGroupAsync(Guid id)
        {
            var group = await _unitOfWork.Groups.GetByIdAsync(id);

            if (group is null)
                throw new InvalidOperationException(
                    "المجموعة المطلوب حذفها غير موجودة.");

            if (group.GroupName == InitUserGroup.Administrator)
                return false;

            var hasEmployees = await _unitOfWork.Employees
                .NoTrackingSelect()
                .AnyAsync(e => e.GroupGuid == id);

            if (hasEmployees)
                return false;

            _unitOfWork.Groups.Delete(group);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<GroupDto>> GetAllGroupsAsync()
        {
            var groups = await _unitOfWork.Groups
                .NoTrackingSelect()
                .Include(g => g.GroupRoles.Select(gr => gr.Role))
                .ToListAsync();

            return groups.Select(ToDto).ToList();
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.Roles
                .NoTrackingSelect()
                .ToListAsync();

            return roles
                .GroupBy(r => r.RoleName)
                .Select(g => g.First())
                .Select(r => new RoleDto
                {
                    Id = r.Id,
                    RoleName = r.RoleName,
                    Notes = r.Notes
                })
                .ToList();
        }

        public async Task<GroupDto> GetGroupByIdAsync(Guid id)
        {
            var group = await _unitOfWork.Groups
                .NoTrackingSelect()
                .Include(g => g.GroupRoles.Select(gr => gr.Role))
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group is null)
                throw new InvalidOperationException(
                    "المجموعة المطلوبة غير موجودة.");

            return ToDto(group);
        }

        public async Task<bool> UpdateGroupAsync(UpdateGroupDto model)
        {
            if (model is null)
                throw new ArgumentNullException(
                    nameof(model),
                    "بيانات المجموعة مطلوبة.");

            if (string.IsNullOrWhiteSpace(model.GroupName))
                throw new ArgumentException("اسم المجموعة مطلوب.");

            var group = await _unitOfWork.Groups
                .GetByIdAsync(model.Id);

            if (group is null)
                throw new InvalidOperationException(
                    "المجموعة المطلوب تعديلها غير موجودة.");

            var administratorGroupName =
                InitUserGroup.Administrator;

            if (group.GroupName == administratorGroupName ||
                model.GroupName == administratorGroupName)
            {
                return false;
            }

            var hasRepeatedName = await _unitOfWork.Groups
                .NoTrackingSelect()
                .AnyAsync(g =>
                    g.Id != model.Id &&
                    g.GroupName == model.GroupName);

            if (hasRepeatedName)
                return false;

            group.GroupName = model.GroupName;
            group.Notes = model.Notes;

            var roleIds = (model.GroupRoles)
    .Select(gr => gr.RoleGuid)
    .Distinct() 
    .ToList();

            var roles = await _unitOfWork.Roles
                .Select()
                .Where(r => roleIds.Contains(r.Id))
                .ToListAsync();

            var oldGroupRoles = await _unitOfWork.GroupRoles
                .Select()
                .Where(gr => gr.GroupGuid == group.Id)
                .ToListAsync();

            var rolesToDelete = oldGroupRoles
                .Where(gr => !roles.Any(r => r.Id == gr.RoleGuid))
                .ToList();

            if (rolesToDelete.Count > 0)
            {
                _unitOfWork.GroupRoles.DeleteRange(rolesToDelete);
            }

            foreach (var role in roles)
            {
                var exists = oldGroupRoles
                    .Any(gr => gr.RoleGuid == role.Id);

                if (!exists)
                {
                    _unitOfWork.GroupRoles.Add(new GroupRole
                    {
                        GroupGuid = group.Id,
                        RoleGuid = role.Id
                    });
                }
            }

            _unitOfWork.Groups.Update(group);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        private static GroupDto ToDto(Group group)
        {
            var groupRoles = group.GroupRoles
                .Where(gr => !gr.IsDeleted)
                .Select(gr => new GroupRoleDto
                {
                    Id = gr.Id,
                    GroupGuid = gr.GroupGuid,
                    RoleGuid = gr.RoleGuid,
                    Role = gr.Role == null ? null : new RoleDto
                    {
                        Id = gr.Role.Id,
                        RoleName = gr.Role.RoleName
                    }
                })
                .ToList();

            return new GroupDto
            {
                Id = group.Id,
                GroupName = group.GroupName,
                Notes = group.Notes,
                GroupRoles = groupRoles
            };
        }
    }

}