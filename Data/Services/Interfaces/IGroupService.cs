using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<GroupDto>> GetAllGroupsAsync();
        Task<GroupDto> GetGroupByIdAsync(Guid id);
        Task<List<RoleDto>> GetAllRolesAsync();
        Task<bool> CreateGroupAsync(CreateGroupDto model);
        Task<bool> UpdateGroupAsync(UpdateGroupDto model);
        Task<bool> DeleteGroupAsync(Guid modelId);
    }
}