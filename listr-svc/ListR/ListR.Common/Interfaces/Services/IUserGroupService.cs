using ListR.DataLayer.EntityModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListR.Common.Interfaces.Services
{
    public interface IUserGroupService
    {
        Task CreateUserGroup(UserGroup model);
        Task UpdateUserGroup(UserGroup model);
        Task<UserGroup?> GetUserGroup(string userId);
    }
}
}
