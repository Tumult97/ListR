using ListR.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListR.DataLayer.EntityModels.Lists
{
    public class ListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ListId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ListItemTypeEnum ItemType { get; set; }

        public Priority Priority { get; set; }

        public bool IsCollected { get; set; } = false;

        public decimal Price { get; set; }
    }
}
