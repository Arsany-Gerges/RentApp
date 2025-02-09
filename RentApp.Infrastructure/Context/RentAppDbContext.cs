using Microsoft.EntityFrameworkCore;
using System;
using RentApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Infrastructure
{
    public class RentAppDbContext : DbContext
    {
        public RentAppDbContext(DbContextOptions<RentAppDbContext> options) : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Apartment_Images> ApartmentImages { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Room_Images> RoomImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apartment → ApartmentImages (One-to-Many)
            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Apartment_Images)
                .WithOne(ai => ai.Apartment)
                .HasForeignKey(ai => ai.ApartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // Apartment → Assets (One-to-Many)
            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Assets)
                .WithOne(asset => asset.Apartment)
                .HasForeignKey(asset => asset.ApartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // Apartment → Rooms (One-to-Many)
            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Rooms)
                .WithOne(r => r.Apartment)
                .HasForeignKey(r => r.ApartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // Room → RoomImages (One-to-Many)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.RoomImages)
                .WithOne(ri => ri.Room)
                .HasForeignKey(ri => ri.RoomID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}