using ListR.DataLayer.EntityModels.Lists;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListR.DataLayer.EntityModels.Users
{
    public class UserGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? UserCreatedBy { get; set; }

        public ICollection<User>? Users { get; set; }

        public ICollection<ShopList>? Lists { get; set; }

        [NotMapped]
        public List<string>? UserIds { get; set; }
    }
}
