using HotelReservationSystem.Models.OfferManagement;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem.Data;

public class Context : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<UserFeature> UserFeatures { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Room> rooms { get; set; }
    public DbSet<RoomFacility> roomFacilities { get; set; }
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
