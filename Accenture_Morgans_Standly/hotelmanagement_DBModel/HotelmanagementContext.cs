using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Accenture_Morgans_Standly.hotelmanagement_DBModel;

public partial class HotelmanagementContext : DbContext
{
    public HotelmanagementContext()
    {
    }

    public HotelmanagementContext(DbContextOptions<HotelmanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<NewBooking> NewBookings { get; set; }

    public virtual DbSet<SipDashboard> SipDashboards { get; set; }

  // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //     => optionsBuilder.UseSqlServer("Server=DESKTOP-OLCB1UC;Database=hotelmanagement;Trusted_Connection=True;Encrypt=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bookings");

            entity.Property(e => e.CustomerName)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cities");

            entity.Property(e => e.CityName)
                .IsUnicode(false)
                .HasColumnName("cityName");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("countries");

            entity.Property(e => e.CountryName)
                .IsUnicode(false)
                .HasColumnName("countryName");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employee");

            entity.Property(e => e.Empid)
                .ValueGeneratedOnAdd()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Empsalary)
                .HasColumnType("money")
                .HasColumnName("empsalary");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__17ADC472632974BA");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelDescription)
                .IsUnicode(false)
                .HasColumnName("hotelDescription");
            entity.Property(e => e.HotelImage)
                .IsUnicode(false)
                .HasColumnName("hotelImage");
            entity.Property(e => e.HotelLocation)
                .IsUnicode(false)
                .HasColumnName("hotelLocation");
            entity.Property(e => e.HotelName)
                .IsUnicode(false)
                .HasColumnName("hotelName");
        });

        modelBuilder.Entity<NewBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewBooki__3213E83F0405F3F6");

            entity.ToTable("NewBooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.Country).IsUnicode(false);
            entity.Property(e => e.CustomerName).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<SipDashboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sip_Dashboard");

            entity.Property(e => e.Location)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .ValueGeneratedOnAdd()
                .HasColumnName("position");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("symbol");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
