using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
using System.Security.Claims;
=======
<<<<<<< Updated upstream
=======
using System.Security.Claims;
using System.Text.Json.Serialization;
>>>>>>> Stashed changes
>>>>>>> SVC_Vanguard

namespace ListR.DataLayer.EntityModels.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

<<<<<<< HEAD
<<<<<<< Updated upstream
        public ICollection<UserGroup> UserGroups { get; set; }
=======
        [NotMapped]
        [JsonIgnore]
        public List<UserGroup>? UserGroups { get; set; }

        [NotMapped]
<<<<<<< HEAD
        public List<Claim>? claims { get; set; }
=======
        [JsonIgnore]
        public List<Claim>? claims { get; set; }
>>>>>>> Stashed changes
=======
        [NotMapped]
        public List<UserGroup>? UserGroups { get; set; }
>>>>>>> SVC_Vanguard
>>>>>>> SVC_Vanguard
    }
}
