using ListR.DataLayer.EntityModels.Lists;
using ListR.DataLayer.EntityModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ListR.DataLayer
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserGroups)
                .WithMany(x => x.Users)
                .UsingEntity(o => o.ToTable("UserGroupMappings"));

            modelBuilder.Entity<ShopList>()
                .HasMany(x => x.ListItems);

            modelBuilder.Entity<ShopList>()
                .HasMany(x => x.ListItems);

            base.OnModelCreating(modelBuilder);
        }

        #region [ DbSets ]

        #region [ Users ]

        public DbSet<UserGroup> UserGroups { get; set; }

        #endregion

        #region [ List ]
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<ListItem> listItems { get; set; }
        #endregion

        #endregion
    }
}
