using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.EntityFramework
{
    public partial class ClubMedDbContext : DbContext
    {
        public ClubMedDbContext() { }
        public ClubMedDbContext(DbContextOptions<ClubMedDbContext> options) : base(options) { }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<DomaineSkiable> Domaines { get; set; } = null!;

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

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
