using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreSamples
{
    public class EFCoreSamplesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlaystationPlus> PlaystationPlus { get; set; }
        public DbSet<Console> Consoles { get; set; }
        public DbSet<Trophy> Trophies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog= EFCoreSamples");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.CreationDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PlaystationPlus>()
                .HasKey(ps => ps.SubscriptionId);

            modelBuilder.Entity<PlaystationPlus>()
                .Property(ps => ps.Active)
                .HasDefaultValue(true);

            modelBuilder.Entity<PlaystationPlus>()
                .Property(ps => ps.SubscribedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Console>()
                .HasKey(c => c.ConsoleId);

            modelBuilder.Entity<Console>()
                .Property(c => c.SerialNumber)
                .IsRequired()
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Trophy>()
                .HasKey(t => t.TrophyId);

            modelBuilder.Entity<Trophy>()
                .Property(t => t.Rarity)
                .HasConversion(
                    v => v.ToString(),
                    v => (TrophyRarity)Enum.Parse(typeof(TrophyRarity), v));
        }
    }
}
