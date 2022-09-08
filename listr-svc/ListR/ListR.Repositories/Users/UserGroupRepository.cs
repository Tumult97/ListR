using Dapper;
using ListR.Common.DatbaseQueries;
using ListR.Common.Interfaces.Repositories;
using ListR.DataLayer;
using ListR.DataLayer.EntityModels.Lists;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
            //using (var conn = _context.Database.GetDbConnection())
            //{
            //    var data = conn.Query<ShopList, UserGroup, UserGroup>(
            //        DatabaseQueries.UserGroupsGetAllByEmail(email).ToString(),
            //        (shopList, user) =>
            //        {
            //            if (user.Lists == null) user.Lists = new List<ShopList>();
            //            user.Lists.Add(shopList);
            //            return user;
            //        }).ToList(); 
            //    return data;
            //}
            var model = await _context.UserGroups.Include(x => x.Users).Include(x => x.Lists).ThenInclude(o => o.ListItems).Where(x => x.Users.Any(x => x.Email == email)).ToListAsync();

            return model;
        }

        public async Task<UserGroup?> GetUserGroupByUserId(int userGroupId) => await _context.UserGroups
            .FromSqlInterpolated(DatabaseQueries.UserGroupsGetById(userGroupId)).FirstOrDefaultAsync();

        public void UpdateUserGroup(UserGroup model)
        {
            _context.UserGroups.Update(model);
        }

        public async Task AddUsersToGroup(List<UserGroupMapping> models)
        {
            var group = (await _context.UserGroups.Include(x => x.Users).Where(x => x.Id == models[0].UserGroupsId).FirstOrDefaultAsync());
            var users = await _context.Users.Where(x => models.Select(o => o.UsersId).Contains(x.Email)).ToListAsync();

            foreach (var user in users)
            {
                if (!group.Users.Any(x => x.Email == user.Email)) group.Users.Add(user);
            }

            _context.UserGroups.Update(group);
            await _context.SaveChangesAsync();

            //await _context.UserGroupMappings.AddRangeAsync(models);
        }
    }
}
