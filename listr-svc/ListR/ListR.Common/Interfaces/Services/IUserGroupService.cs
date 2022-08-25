using ListR.DataLayer.EntityModels.Users;

namespace ListR.Common.Interfaces.Services
{
    public interface IUserGroupService
    {
        Task CreateUserGroup(UserGroup model);
        Task UpdateUserGroup(UserGroup model);
        Task<List<UserGroup>> GetUserGroupsByEmail(string email);
        Task AddUsersToUserGroup(List<string> ids, int userGroupId);
    }
}
