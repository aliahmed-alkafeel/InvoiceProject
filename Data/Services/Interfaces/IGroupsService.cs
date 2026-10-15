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
        Task<bool> CreateGroupAsync(GroupDto model);
        Task<bool> UpdateGroupAsync(GroupDto model);
        Task<bool> DeleteGroupAsync(Guid modelId);
    }
}