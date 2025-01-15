using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.OfferManagement;
using HotelReservationSystem.Models.PaymentManagement;
using HotelReservationSystem.Models.ReservationManagement;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

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
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<RType> RTypes { get; set; }
    public DbSet<RoomFacility> RoomFacilities { get; set; }
    public DbSet<RTypeFacility> RTypeFacilities { get; set; }

    // Reservation Management
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationRoom> ReservationRooms { get; set; }
    
    // Guest Management
    public DbSet<Guest> Guests { get; set; }
    
    
    // Payment Management
    public DbSet<Payment> Payments { get; set; }
    
    // Offers Management
    public DbSet<Offer> Offers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationRoomGuest>()
            .HasOne(rg => rg.ReservationRoom)
            .WithMany(rr => rr.ReservationRoomGuests)
            .HasForeignKey(rg => rg.ReservationRoomID)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
    }
}
