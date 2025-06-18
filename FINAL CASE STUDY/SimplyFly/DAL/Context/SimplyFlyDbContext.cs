using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.DAL.Context
{
    public class SimplyFlyDbContext : DbContext
    {
        public SimplyFlyDbContext(DbContextOptions<SimplyFlyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Payment> Payments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // to configure relationships and constraints...

            modelBuilder.Entity<User>().HasMany(u => u.Bookings).WithOne(b => b.User).HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Flight>().HasMany(f => f.Routes).WithOne(r => r.Flight).HasForeignKey(r => r.FlightId);

            modelBuilder.Entity<Routes>().HasMany(r => r.Seats).WithOne(s => s.Route).HasForeignKey(s => s.RouteId);

            modelBuilder.Entity<Routes>().HasMany(r => r.Bookings).WithOne(b => b.Route).HasForeignKey(b => b.RouteId);

            modelBuilder.Entity<Booking>().HasMany(b => b.Payments).WithOne(p => p.Booking).HasForeignKey(p => p.BookingId);

        }


    }
}
