using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio
{
    public class PortfolioContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillApp> SkillsApp { get; set; }

        public DbSet<Image> Images { get; set; }

        public PortfolioContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EQ0EU6U\\SQLEXPRESS;Initial Catalog=portfolio;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasMany(e => e.Skills).WithOne(e => e.User).HasForeignKey(e => e.UserId); 
            modelBuilder.Entity<User>().HasMany(e => e.Products).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Images)
                .WithMany(e => e.Products);
               // .UsingEntity(e => e.ToTable("ImagesProducts"));

            modelBuilder.Entity<SkillApp>().HasMany(e => e.Skills).WithOne(e => e.SkillApp).HasForeignKey(e => e.SkillAppId);

            //base.OnModelCreating(modelBuilder);

        }
    }
}
