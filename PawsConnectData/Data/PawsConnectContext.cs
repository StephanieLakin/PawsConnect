using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using PawsConnectData.Entities;


namespace PawsConnectData.Data
{
    public class PawsConnectContext : DbContext
    {
        public PawsConnectContext(DbContextOptions<PawsConnectContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<LostFoundAlert> LostFoundAlerts { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Dog>().ToTable("Dogs");
            modelBuilder.Entity<HealthRecord>().ToTable("HealthRecords");
            modelBuilder.Entity<ActivityLog>().ToTable("ActivityLogs");
            modelBuilder.Entity<CommunityPost>().ToTable("CommunityPosts");
            modelBuilder.Entity<LostFoundAlert>().ToTable("LostFoundAlerts");
            modelBuilder.Entity<Service>().ToTable("Services");



            modelBuilder.Entity<User>()
                .HasMany(u => u.Dogs)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Dog>()
                .HasMany(d => d.HealthRecords)
                .WithOne(h => h.Dog)
                .HasForeignKey(h => h.DogId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Dog>()
                .HasMany(d => d.ActivityLogs)
                .WithOne(a => a.Dog)
                .HasForeignKey(a => a.DogId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Dog>()
                .Property(d => d.Name)
                .IsRequired();
            
            modelBuilder.Entity<Dog>()
                .Property(d => d.Bio)
                .HasMaxLength(500);


            modelBuilder.Entity<User>()
                .HasMany(u => u.CommunityPosts)
                .WithOne(cp => cp.User)
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LostFoundAlert>()
                .HasOne(lfa => lfa.User)
                .WithMany(u => u.LostFoundAlerts)
                .HasForeignKey(lfa => lfa.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LostFoundAlert>()
                .HasOne(lfa => lfa.Dog)
                .WithMany(d => d.LostFoundAlerts)
                .HasForeignKey(lfa => lfa.DogId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
