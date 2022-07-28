

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListR.DataLayer.EntityModels.Lists
{
    public class ShopList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string color { get; set; } = string.Empty;

        [Required]
        public bool isDeleted { get; set; } = false;

        [Required]
        public bool isCompleted { get; set; } = false;

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int UserCreatedBy { get; set; }

        public int UserGroupId { get; set; }

        public DateTime DateCompleted { get; set; }

    }
}
