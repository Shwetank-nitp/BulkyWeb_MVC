using BulkyEd_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyEd_Razor.Data
{
    public class ApplicationDbContent: DbContext
    {
        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options)
        : base(options)
        { }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, CategoryName = "Si-Fi", CaregoryOrder = 1 },
                new Category { ID=2, CategoryName="Suspense Thriller",CaregoryOrder = 2 },
                new Category { ID=3,CategoryName="MCU", CaregoryOrder=3}
                );
            ;
        }
    }
}
