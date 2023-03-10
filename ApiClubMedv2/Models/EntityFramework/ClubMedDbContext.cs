using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.EntityFramework
{
    public partial class ClubMedDbContext : DbContext
    {
        public ClubMedDbContext() { }
        public ClubMedDbContext(DbContextOptions<ClubMedDbContext> options) : base(options) { }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<DomaineSkiable> Domaines { get; set; } = null!;
        public virtual DbSet<Multimedia> Multimedias { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;

        public static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity
                    .HasIndex(c => c.Email)
                    .IsUnique();

                entity
                    .HasOne(d => d.Domaine)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.IdDomaineSkiable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_dsk");
            });

            modelBuilder.Entity<DomaineSkiable>(entity =>
            {
                entity
                    .HasCheckConstraint("ck_dsk_altbasse_althaute", "dsk_altitudebasse > 0 and dsk_altitudehaute > dsk_altitudebasse");

                entity
                    .HasCheckConstraint("ck_dsk_longueurpistes", "dsk_longueurpistes > 0");

                entity
                    .HasCheckConstraint("ck_dsk_nombrepistes", "dsk_nbpistes > 0");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity
                    .HasCheckConstraint("ck_trp_prix", "trp_prix > 0");
            });

            modelBuilder.Entity<ClubMultimedia>(entity =>
            {
                entity
                    .HasKey(cm => new { cm.IdClub, cm.IdMultimedia });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubMultimedias)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cmt");

                entity
                    .HasOne(d => d.Multimedia)
                    .WithMany(p => p.ClubMultimedias)
                    .HasForeignKey(d => d.IdMultimedia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mtm_cmt");
            });

            modelBuilder.Entity<ClubTransport>(entity =>
            {
                entity
                    .HasKey(ct => new { ct.IdClub, ct.IdTransport });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubTransports)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_ctr");

                entity
                    .HasOne(d => d.Transport)
                    .WithMany(p => p.ClubTransports)
                    .HasForeignKey(d => d.IdTransport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cmb_ctr");
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
