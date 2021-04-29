using Microsoft.EntityFrameworkCore;

namespace EFCoreSamples
{
    public class EFCoreSamplesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlaystationPlus> PlaystationPlus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog= EFCoreSamples");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaystationPlus>()
                .HasKey(ps => ps.SubscriptionId);

            modelBuilder.Entity<PlaystationPlus>()
                .Property(ps => ps.Active).HasDefaultValue(true);

            modelBuilder.Entity<PlaystationPlus>()
                .Property(ps => ps.SubscribedDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(u => u.CreationDate).HasDefaultValueSql("getdate()");
        }
    }
}
