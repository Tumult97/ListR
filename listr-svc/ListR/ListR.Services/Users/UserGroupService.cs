using ListR.Common.Interfaces.Repositories;
using ListR.Common.Interfaces.Services;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ListR.Services.Users
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserGroupService(
            IUserGroupRepository userGroupRepository, 
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userGroupRepository = userGroupRepository;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateUserGroup(UserGroup model)
        {
            await _userGroupRepository.CreateUserGroup(model);
            await _userGroupRepository.SaveChangesAsync();
        }

        public async Task<List<UserGroup>> GetUserGroupsByEmail(string email)
        {
            return await _userGroupRepository.GetUserGroupsByEmail(email);
        }

        public async Task UpdateUserGroup(UserGroup model)
        {
            _userGroupRepository.UpdateUserGroup(model);
            await _userGroupRepository.SaveChangesAsync();
        }

        public async Task AddUsersToUserGroup(List<string> ids, int userGroupId)
        {
            List<UserGroupMapping> models = ids.Select(x => new UserGroupMapping
            {
                UsersId = x,
                UserGroupsId = userGroupId
            }).ToList();

            await _userGroupRepository.AddUsersToGroup(models);
            await _userGroupRepository.SaveChangesAsync();
        }
    }
}
