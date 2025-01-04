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
    protected Context() { }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    // Users Management
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserFeature> UserFeatures { get; set; }
    public DbSet<RoleFeatures> RoleFeatures { get; set; }

    // Rooms Management
    public DbSet<Room> rooms { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<RoomFacility> RoomFacilities { get; set; }
    public DbSet<RoomTypeFacility> RoomTypeFacilities { get; set; }

    // Offers Management
    public DbSet<Offer> Offers { get; set; }

}
