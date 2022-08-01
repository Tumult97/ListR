using ListR.DataLayer.EntityModels.Users;

namespace ListR.Common.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUser(string email);
    Task UpdateUser(User model);
    Task DeleteUser(string email);
}