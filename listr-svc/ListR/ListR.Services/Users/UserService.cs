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
        var user = await _userManager.FindByEmailAsync(email);
        return new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            Email = user.Email
        };
    }

    public async Task UpdateUser(User model)
    {
        await _userManager.UpdateAsync(model);
        
    }

    public async Task DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.DeleteAsync(user);
    }
}