using ListR.DataLayer.EntityModels.Lists;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.EntityFrameworkCore;

namespace ListR.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region [ DbSets ]

        #region [ Users ]

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroupMapping> UserGroupMappings { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        #endregion

        #region [ List ]
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<ListItem> listItems { get; set; }
        #endregion

        #endregion
    }
}
