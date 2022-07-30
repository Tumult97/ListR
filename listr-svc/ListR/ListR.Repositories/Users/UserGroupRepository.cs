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

        public async Task CreateUserGroup(UserGroup model)
        {
            await _context.UserGroups.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<UserGroup?> GetUserGroup(string userId)
        {
            UserGroup? model = await _context.UserGroups
                                            .Include(x => x.Users)
                                            .Include(x => x.Lists)
                                            .Where(
                                                x => x.Users.Any(o => o.Id == userId)
                                            ).FirstOrDefaultAsync();

            return model;
        }

        public Task UpdateUserGroup(UserGroup model)
        {
            throw new NotImplementedException();
        }
    }
}
