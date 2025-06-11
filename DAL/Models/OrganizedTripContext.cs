using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class OrganizedTripContext : DbContext
{
    public OrganizedTripContext()
    {
    }

    public OrganizedTripContext(DbContextOptions<OrganizedTripContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8ED3CL9;Database=OrganizedTrip;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationCode).HasName("PK__Reservat__DD450469465E9ADB");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationCode).HasColumnName("reservationCode");
            entity.Property(e => e.BookerName)
                .HasMaxLength(100)
                .HasColumnName("bookerName");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .HasColumnName("contactPhone");
            entity.Property(e => e.NumberSeats).HasColumnName("numberSeats");
            entity.Property(e => e.ReservationDate)
                .HasPrecision(0)
                .HasColumnName("reservationDate");
            entity.Property(e => e.TourCode).HasColumnName("tourCode");

            entity.HasOne(d => d.TourCodeNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TourCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__tourC__267ABA7A");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripCode).HasName("PK__Trip__FDA36B64F5796797");

            entity.ToTable("Trip");

            entity.Property(e => e.TripCode).HasColumnName("tripCode");
            entity.Property(e => e.AvailablePlaces).HasColumnName("availablePlaces");
            entity.Property(e => e.DepartureTime)
                .HasPrecision(0)
                .HasColumnName("departureTime");
            entity.Property(e => e.Destination)
                .HasMaxLength(100)
                .HasColumnName("destination");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TripDate)
                .HasColumnType("date")
                .HasColumnName("tripDate");
            entity.Property(e => e.TripDuration).HasColumnName("tripDuration");
            entity.Property(e => e.TripType)
                .HasMaxLength(50)
                .HasColumnName("tripType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
