

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ListR.DataLayer.EntityModels.Lists
{
    public class ShopList
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string color { get; set; } = string.Empty;

        public bool isDeleted { get; set; } = false;

        public bool isCompleted { get; set; } = false;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string UserCreatedBy { get; set; } = string.Empty;

        public int UserGroupId { get; set; }

        public DateTime? DateCompleted { get; set; }

        [JsonIgnore]
        public ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();

    }
}
