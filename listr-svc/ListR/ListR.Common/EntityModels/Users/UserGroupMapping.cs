using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListR.DataLayer.EntityModels.Users;

public class UserGroupMapping
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("UserGroups")]
    public int UserGroupsId { get; set; }

    [ForeignKey("User")]
    public string UsersId { get; set; }
}