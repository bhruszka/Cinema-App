using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Data {
    public class CinemaDbContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public CinemaDbContext (DbContextOptions<CinemaDbContext> options) : base (options) { }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Reservation> ()
                .HasKey (r => new { r.ScreeningId, r.SeatId });
        }
    }
}