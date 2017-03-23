using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobiWifiApp
{
    public partial class cmxContext : DbContext
    {
        public virtual DbSet<CmxEvents> CmxEvents { get; set; }
        public virtual DbSet<CmxObservations> CmxObservations { get; set; }

        // Unable to generate entity type for table 'public.cmx_apfloors'. Please see the warning messages.
        // Unable to generate entity type for table 'public.cmx_aptags'. Please see the warning messages.
        // Unable to generate entity type for table 'public.cmx_positions'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=cmx;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmxEvents>(entity =>
            {
                entity.ToTable("cmx_events");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('events_id_seq'::regclass)");

                entity.Property(e => e.Apmac)
                    .IsRequired()
                    .HasColumnName("apmac");

                entity.Property(e => e.Received)
                    .HasColumnName("received")
                    .HasColumnType("timestamptz")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<CmxObservations>(entity =>
            {
                entity.ToTable("cmx_observations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('observations_id_seq'::regclass)");

                entity.Property(e => e.Clientmac)
                    .IsRequired()
                    .HasColumnName("clientmac");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Ipv4).HasColumnName("ipv4");

                entity.Property(e => e.Ipv6).HasColumnName("ipv6");

                entity.Property(e => e.LocationLat).HasColumnName("location_lat");

                entity.Property(e => e.LocationLng).HasColumnName("location_lng");

                entity.Property(e => e.LocationUnc).HasColumnName("location_unc");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Os).HasColumnName("os");

                entity.Property(e => e.Rssi).HasColumnName("rssi");

                entity.Property(e => e.Seentime)
                    .HasColumnName("seentime")
                    .HasColumnType("timestamptz");

                entity.Property(e => e.Ssid).HasColumnName("ssid");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CmxObservations)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("observations_eventid_fkey");
            });

            modelBuilder.HasSequence("events_id_seq");

            modelBuilder.HasSequence("observations_id_seq");

            modelBuilder.HasSequence("positions_id_seq");
        }
    }
}