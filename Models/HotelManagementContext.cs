using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelManagementWebAPI.Models
{
    public partial class HotelManagementContext : DbContext
    {
        public HotelManagementContext()
        {
        }

        public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Miscellaneous> Miscellaneous { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<RoomNo> RoomNo { get; set; }
        public virtual DbSet<RoomStatus> RoomStatus { get; set; }

      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SAMEENAF\\SQLEXPRESS; Initial Catalog= HotelManagement; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RatingType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Misc)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.MiscId)
                    .HasConstraintName("FK__Category__MiscId__38996AB5");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__049E3AA9E735A71A");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Miscellaneous>(entity =>
            {
                entity.HasKey(e => e.MiscId)
                    .HasName("PK__Miscella__59EFD891FD1D5901");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.BookDate).HasColumnType("datetime");

                entity.Property(e => e.OccupancyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__Reservati__CustI__4316F928");

                entity.HasOne(d => d.RoomNo)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomNoId)
                    .HasConstraintName("FK__Reservati__RoomN__440B1D61");
            });

            modelBuilder.Entity<RoomNo>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RoomNo)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__RoomNo__Category__3D5E1FD2");

                entity.HasOne(d => d.RoomStatus)
                    .WithMany(p => p.RoomNo)
                    .HasForeignKey(d => d.RoomStatusId)
                    .HasConstraintName("FK__RoomNo__RoomStat__3E52440B");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.Property(e => e.OccupationStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
