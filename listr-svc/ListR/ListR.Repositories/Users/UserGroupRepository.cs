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

        public async Task<List<UserGroup>> GetUserGroupsByEmail(string email)
        {
            var model = await _context.UserGroups
                                            .Include(x => x.Users)
                                            .Include(x => x.Lists)
                                            .Where(
                                                x => x.Users != null && x.Users.Any(o => o.Email == email)
                                            ).ToListAsync();

            return model;
        }

        public async Task<UserGroup?> GetUserGroupByUserId(int userGroupId)
        {
            var model = await _context.UserGroups
                .Include(x => x.Users)
                .Include(x => x.Lists)
                .Where(
                    x => x.Id == userGroupId
                ).FirstOrDefaultAsync();

            return model;
        }

        public void UpdateUserGroup(UserGroup model)
        {
            _context.UserGroups.Update(model);
        }
    }
}
