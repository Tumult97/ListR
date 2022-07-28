

using ListR.DataLayer.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ListR.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
