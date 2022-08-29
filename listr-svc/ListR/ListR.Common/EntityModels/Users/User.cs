using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace ListR.DataLayer.EntityModels.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public List<UserGroup>? UserGroups { get; set; }

        [NotMapped]
        public List<Claim>? claims { get; set; }
    }
}
