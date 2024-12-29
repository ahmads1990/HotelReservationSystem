using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem.Data;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = .\SQLExpress; Initial Catalog =HotelReservationSystem;Integrated security = true;trust server certificate = true")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}
