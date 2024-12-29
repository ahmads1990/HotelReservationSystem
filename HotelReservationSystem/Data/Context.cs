using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.OfferManagement;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<RType> RTypes { get; set; }
    public DbSet<RoomFacilities> RoomFacilities { get; set; }
    public DbSet<RTypeFacilities> RTypeFacilities { get; set; }

    // Offers Management

    public DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}
//Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False