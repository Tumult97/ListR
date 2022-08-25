using ListR.DataLayer.EntityModels.Users;

namespace ListR.Common.Interfaces.Repositories
{

    public interface IUserGroupRepository
    {
        Task SaveChangesAsync();
        
        Task CreateUserGroup(UserGroup model);
        
        void UpdateUserGroup(UserGroup model);

        Task<List<UserGroup>> GetUserGroupsByEmail(string email);

        Task<UserGroup?> GetUserGroupByUserId(int userGroupId);

        Task AddUsersToGroup(List<UserGroupMapping> models);
    }
}
