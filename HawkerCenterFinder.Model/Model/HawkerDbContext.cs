using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace HawkerCenterFinder.Model
{
    public class HawkerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserCredentials> UserCredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=hawker.db");
            base.OnConfiguring(options);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            builder.Entity<UserCredentials>().ToTable("UserCredentials");
            builder.Entity<UserCredentials>(entity =>
            {
                entity.HasKey(i => i.Username);
                entity.HasIndex(i => i.Username).IsUnique();
                entity.HasIndex(i => i.Password).IsUnique();
            });
            builder.Entity<Hawker>().ToTable("Hawker");
            builder.Entity<Hawker>(entity =>
            {
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.HasKey(i => i.Name);
                entity.HasIndex(i => i.Latitude).IsUnique();
                entity.HasIndex(i => i.Longitude).IsUnique();
            });
            base.OnModelCreating(builder);
        }
    }
}

