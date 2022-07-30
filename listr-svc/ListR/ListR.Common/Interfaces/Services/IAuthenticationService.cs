using ListR.Common.Models.Auth;
using ListR.DataLayer.EntityModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ListR.Common.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<List<Claim>> Login(LoginModel model);
        Task<RegisterStatusModel> Register(RegisterModel model);
        Task<RegisterStatusModel> RegisterAdmin(RegisterModel model);
    }
}
