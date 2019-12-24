using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.Contexts.Models;

namespace DAL.Contexts
{
    public partial class OpenroomContext : DbContext
    {
        public OpenroomContext()
        {
        }

        public OpenroomContext(DbContextOptions<OpenroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patron> Patron { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Database=Openroom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patron>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVATION_PATRON");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVATION_RESOURCE");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
