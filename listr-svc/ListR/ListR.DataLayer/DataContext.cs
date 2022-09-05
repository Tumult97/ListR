﻿using ListR.DataLayer.EntityModels.Lists;
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

          //  modelBuilder.Entity<User>()
          //      .HasMany

          //  modelBuilder.Entity<Library2Book>()
          //.HasOne(x => x.Book)
          //.WithMany(x => x.Library2Books)
          //.HasForeignKey(x => x.BookId);

          //  modelBuilder.Entity<Library2Book>()
          //     .HasOne(x => x.Library)
          //     .WithMany(x => x.Library2Books)
          //     .HasForeignKey(x => x.LibraryId);

            modelBuilder.Entity<UserGroup>()
                .HasMany(x => x.Lists);

            modelBuilder.Entity<ShopList>()
                .HasMany(x => x.ListItems);

            base.OnModelCreating(modelBuilder);
        }

        #region [ DbSets ]

        #region [ Users ]

        public DbSet<UserGroup> UserGroups { get; set; }
        //public DbSet<UserGroupMapping> UserGroupMappings { get; set; }

        #endregion

        #region [ List ]
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<ListItem> listItems { get; set; }
        #endregion

        #endregion
    }
}
