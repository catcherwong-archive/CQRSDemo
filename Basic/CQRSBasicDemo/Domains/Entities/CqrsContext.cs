namespace CQRSBasicDemo.Domains.Entities
{
    using Microsoft.EntityFrameworkCore;
    
    public class CqrsContext : DbContext
    {
        public CqrsContext(DbContextOptions<CqrsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("t_user");

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .HasColumnName("id");

            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasColumnName("name");


        }
    }
}
