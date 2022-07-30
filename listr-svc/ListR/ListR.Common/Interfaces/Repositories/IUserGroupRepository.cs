using ListR.DataLayer.EntityModels.Users;

namespace ListR.Common.Interfaces.Repositories
{

    public interface IUserGroupRepository
    {
        Task CreateUserGroup(UserGroup model);
        Task UpdateUserGroup(UserGroup model);
        Task<UserGroup?> GetUserGroup(string userId);
    }
}
