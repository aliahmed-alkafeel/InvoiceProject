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
    public class GroupsService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(
                    nameof(unitOfWork),
                    "وحدة العمل مطلوبة.");
        }

        public async Task<bool> CreateGroupAsync(GroupDto model)
        {
            if (model is null)
                throw new ArgumentNullException(
                    nameof(model),
                    "بيانات المجموعة مطلوبة.");

            if (string.IsNullOrWhiteSpace(model.GroupName))
                throw new ArgumentException("اسم المجموعة مطلوب.");

            var hasRepeatedName = await _unitOfWork.Groups
                .Select()
                .AnyAsync(g => g.GroupName == model.GroupName);

            if (hasRepeatedName)
                return false;

            var roleNames = model.GroupRoles;

            var roles = await _unitOfWork.Roles
                .Select()
                .Where(r => roleNames.Contains(r.RoleName))
                .ToListAsync();

            var group = new Group
            {
                Id = Guid.NewGuid(),
                GroupName = model.GroupName
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

            if (group.GroupName == InitUserGroup.Administrator.ToString())
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
                .Include("GroupRoles.Role")
                .ToListAsync();

            return groups
                .Select(group => new GroupDto
                {
                    Id = group.Id,
                    GroupName = group.GroupName,
                    GroupRoles = group.GroupRoles
                        .Where(gr => !gr.IsDeleted)
                        .ToList()
                })
                .ToList();
        }

        public async Task<GroupDto> GetGroupByIdAsync(Guid id)
        {
            var group = await _unitOfWork.Groups
                .NoTrackingSelect()
                .Include(g => g.GroupRoles)
                .ThenInclude(gr => gr.GroupRole.Role)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group is null)
                throw new InvalidOperationException(
                    "المجموعة المطلوبة غير موجودة.");

            return new GroupDto
            {
                Id = group.Id,
                GroupName = group.GroupName,
                GroupRoles = group.GroupRoles
                    .Where(gr => !gr.IsDeleted)
                    .ToList()
            };
        }

        public async Task<bool> UpdateGroupAsync(GroupDto model)
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
                InitUserGroup.Administrator.ToString();

            // منع تعديل اسم مجموعة المسؤول أو تحويل مجموعة أخرى إليها.
            if (group.GroupName == administratorGroupName ||
                model.GroupName == administratorGroupName)
            {
                return false;
            }

            // منع تكرار اسم المجموعة مع استثناء المجموعة الحالية.
            var hasRepeatedName = await _unitOfWork.Groups
                .NoTrackingSelect()
                .AnyAsync(g =>
                    g.Id != model.Id &&
                    g.GroupName == model.GroupName);

            if (hasRepeatedName)
                return false;

            group.GroupName = model.GroupName;

            var roleNames = model.GroupRoles.Role?.ToList() ?? new List<string>();

            var roles = await _unitOfWork.Roles
                .Select()
                .Where(r => roleNames.Contains(r.RoleName))
                .ToListAsync();

            var oldGroupRoles = await _unitOfWork.GroupRoles
                .Select()
                .Where(gr => gr.GroupGuid == group.Id)
                .ToListAsync();

            // العلاقات التي لم تعد موجودة ضمن الصلاحيات المحددة.
            var rolesToDelete = oldGroupRoles
                .Where(gr => !roles.Any(r => r.Id == gr.RoleGuid))
                .ToList();

            if (rolesToDelete.Count > 0)
            {
                _unitOfWork.GroupRoles.DeleteRange(rolesToDelete);
            }

            // إضافة العلاقات الجديدة فقط.
            foreach (var role in roles)
            {
                var exists = oldGroupRoles
                    .Any(gr => gr.RoleGuid == role.Id);

                if (!exists)
                {
                    await _unitOfWork.GroupRoles.Add(new GroupRole
                    {
                        GroupGuid = group.Id,
                        RoleGuid = role.Id
                    });
                }
            }

            _unitOfWork.Groups.Update(group);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}