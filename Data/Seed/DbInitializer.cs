using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Models.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace Data.Seed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();
                var adminId = Guid.NewGuid();
                var now = DateTime.Now;
                var existingRoles = await context.Roles.Select(r => r.RoleName).ToListAsync();
                var rolesToAdd = ((UserRole[])Enum.GetValues(typeof(UserRole)))
                    .Where(r => !existingRoles.Contains(r)).Select(r => new Role
                {
                    RoleName = r,
                    CreatedById = adminId,
                    CreatedAt = now
                }).ToList();
                if (rolesToAdd.Count > 0)
                {
                    context.Roles.AddRange(rolesToAdd);
                    await context.SaveChangesAsync();
                }

                var existingGroups = await context.Groups.Select(r => r.GroupName).ToListAsync();
                var groupsToAdd = ((InitUserGroup[])Enum.GetValues(typeof(InitUserGroup))).Where(r => !existingGroups.Contains(r.ToString()))
                    .Select(r => new Group
                    {
                        GroupName = r.ToString(),
                        CreatedById = adminId,
                        CreatedAt = now
                    }).ToList();
                if (groupsToAdd.Count > 0)
                {
                    context.Groups.AddRange(groupsToAdd);
                    await context.SaveChangesAsync();
                }

                var adminGroup = await context.Groups.FirstOrDefaultAsync(g => g.GroupName == "Administrator");
                if (adminGroup is null)
                {
                    adminGroup = new Group
                    {
                        GroupName = "Administrator"
                    };
                    context.Groups.Add(adminGroup);
                    await context.SaveChangesAsync();
                }

                var allRoles = await context.Roles.ToListAsync();
                var existingRoleIds = await context.GroupRoles.Where(gr => gr.GroupGuid == adminGroup.Id)
                    .Select(gr => gr.RoleGuid).ToListAsync();
                var groupRolesToAdd = allRoles
                    .Where(r => !existingRoleIds.Contains(r.Id)).Select(r => new GroupRole
                {
                    GroupGuid = adminGroup.Id,
                    RoleGuid = r.Id,
                    CreatedById = adminId,
                    CreatedAt = now
                    }).ToList();
                if (groupRolesToAdd.Count > 0)
                {
                    context.GroupRoles.AddRange(groupRolesToAdd);
                    await context.SaveChangesAsync();
                }

                var admin = await context.Employees.FirstOrDefaultAsync(e => e.Username == "admin");
                if (admin is null)
                {
                    admin = new Employee
                    {
                        Id = adminId,
                        GroupGuid = adminGroup.Id,
                        Username = "admin",
                        Email = "ali3993100@gmail.com",
                        FirstName = "System",
                        LastName = "Admin",
                        PhoneNumber = "02893928934",
                        EmployeeStartingDate = DateTime.Now,
                        Password = "admin",
                        CreatedById = adminId,
                        CreatedAt = now
                    };
                    context.Employees.Add(admin);

                }
                else
                {
                    admin.IsUpdated = true;
                    admin.UpdatedById = admin.Id;
                }


                await context.SaveChangesAsync();
            }
        }
    }
}
