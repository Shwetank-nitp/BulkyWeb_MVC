using BulkyWeb.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "SI-FI", CategoryOrder = 1 },
                new Category { ID = 2, Name = "Horror", CategoryOrder = 2 },
                new Category { ID = 3, Name = "Comedy", CategoryOrder = 3 },
                new Category { ID = 4, Name = "Fantasy", CategoryOrder = 4 }
                );
        }

    }
}
