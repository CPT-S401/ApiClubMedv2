using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.EntityFramework
{
    public partial class ClubMedDbContext : DbContext
    {
        public ClubMedDbContext() { }
        public ClubMedDbContext(DbContextOptions<ClubMedDbContext> options) : base(options) { }

        public virtual DbSet<Club> Clubs { get; set; } = null!;

        public static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
