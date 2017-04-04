using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobiWifiApp.Models
{
    public partial class cmxContext : DbContext
    {
        public virtual DbSet<CmxObservationsLite> CmxObservationsLite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=cmx;Pooling=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmxObservationsLite>(entity =>
            {
                entity.ToTable("cmx_observations_lite");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Clientmac).HasColumnName("clientmac");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Ipv4).HasColumnName("ipv4");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Os).HasColumnName("os");

                entity.Property(e => e.Seenday).HasColumnName("seenday");

                entity.Property(e => e.Seenhour).HasColumnName("seenhour");

                entity.Property(e => e.Seenminute).HasColumnName("seenminute");

                entity.Property(e => e.Seenmonth).HasColumnName("seenmonth");

                entity.Property(e => e.Seenyear).HasColumnName("seenyear");

                entity.Property(e => e.Ssid).HasColumnName("ssid");
            });
        }
    }
}