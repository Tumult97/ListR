using ListR.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListR.DataLayer.EntityModels.Lists
{
    public class ListItem
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Name { get; set; } = string.Empty;

        public ListItemTypeEnum ItemType { get; set; }

        public Priority Priority { get; set; }

        public bool IsCollected { get; set; } = false;

        public decimal Price { get; set; }
    }
}
