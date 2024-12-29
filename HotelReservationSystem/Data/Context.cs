using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.OfferManagement;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem.Data;

public class Context : DbContext
{
    // Users Management

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserFeatures> UserFeatures { get; set; }
    public DbSet<RoleFeatures> RoleFeatures { get; set; }

    // Rooms Management
    public DbSet<Room> rooms { get; set; }
    public DbSet<Facility> roomFacilities { get; set; }
    public DbSet<RType> RTypes { get; set; }
    public DbSet<RoomFacilities> RoomFacilities { get; set; }
    public DbSet<RTypeFacilities> RTypeFacilities { get; set; }

    // Offers Management

    public DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelReservationSystem;Trusted_Connection=True;MultipleActiveResultSets=true")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}
