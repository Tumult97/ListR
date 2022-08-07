using ListR.Common.DatbaseQueries;
using ListR.Common.Interfaces.Repositories;
using ListR.DataLayer;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.EntityFrameworkCore;

namespace ListR.Repositories.Users
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly DataContext _context;

        public UserGroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserGroup(UserGroup model)
        {
            await _context.UserGroups.AddAsync(model);
        }

        public async Task<List<UserGroup>> GetUserGroupsByEmail(string email) => await _context.UserGroups.FromSqlRaw(DatabaseQueries.UserGroupsGetAllByEmail(email).ToString()).ToListAsync();

        public async Task<UserGroup?> GetUserGroupByUserId(int userGroupId) => await _context.UserGroups
            .FromSqlInterpolated(DatabaseQueries.UserGroupsGetById(userGroupId)).FirstOrDefaultAsync();

        public void UpdateUserGroup(UserGroup model)
        {
            _context.UserGroups.Update(model);
        }

        public async Task AddUsersToGroup(List<UserGroupMapping> models)
        {
            await _context.UserGroupMappings.AddRangeAsync(models);
        }
    }
}
