using ListR.Common.Interfaces.Services;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.AspNetCore.Identity;

namespace ListR.Services.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUser(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public Task UpdateUser(User model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(string email)
    {
        throw new NotImplementedException();
    }
}