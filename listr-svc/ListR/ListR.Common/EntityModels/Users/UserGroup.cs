using ListR.DataLayer.EntityModels.Lists;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ListR.DataLayer.EntityModels.Users
{
    public class UserGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? UserCreatedBy { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();

        [JsonIgnore]
        public ICollection<ShopList> Lists { get; set; } = new List<ShopList>();

        [NotMapped]
        public List<string>? UserIds { get; set; }
        
        [NotMapped]
        public bool isCreator { get; set; }
    }
}
