using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBLab3.Db
{
    public partial class MusicTracksDbContext : DbContext
    {
        public MusicTracksDbContext()
        {
        }

        public MusicTracksDbContext(DbContextOptions<MusicTracksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Track> Tracks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-891DTUT;Initial Catalog=everyloop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("tracks", "music");

                entity.Property(e => e.TrackId).ValueGeneratedNever();

                entity.Property(e => e.Composer).HasMaxLength(220);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
