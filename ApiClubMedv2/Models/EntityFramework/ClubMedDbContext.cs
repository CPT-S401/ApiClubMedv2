﻿using APIClubMed.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ApiClubMedv2.Models.EntityFramework
{
    public partial class ClubMedDbContext : DbContext
    {
        public ClubMedDbContext() { }
        public ClubMedDbContext(DbContextOptions<ClubMedDbContext> options) : base(options) { }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<TypeChambre> TypesChambre { get; set; } = null!;
        public virtual DbSet<TypeClub> TypesClub { get; set; } = null!;
        public virtual DbSet<DomaineSkiable> Domaines { get; set; } = null!;
        public virtual DbSet<Multimedia> Multimedias { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<Caracteristique> Caracteristiques { get; set; } = null!;
        public virtual DbSet<Cookie> Cookies { get; set; } = null!;
        public virtual DbSet<Activite> Activites { get; set; } = null!;
        public virtual DbSet<ActiviteEnfant> ActivitesEnfant { get; set; } = null!;
        public virtual DbSet<TypeActivite> TypesActivite { get; set; } = null!;
        public virtual DbSet<Bar> Bars { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<Ville> Villes { get; set; } = null!;
        public virtual DbSet<Pays> Pays { get; set; } = null!;
        public virtual DbSet<CodePostal> CodesPostaux { get; set; } = null!;
        public virtual DbSet<Localisation> Localisations { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Avis> Avis { get; set; } = null!;

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

            modelBuilder.Entity<Bar>(entity =>
            {
                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.Bars)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_bar");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_ret");
            });

            modelBuilder.Entity<Activite>(entity =>
            {
                entity
                    .HasOne(d => d.TypeActivite)
                    .WithMany(p => p.Activites)
                    .HasForeignKey(d => d.IdTypeActivite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_act_tac");

                entity
                    .HasCheckConstraint("ck_act_agemin", "act_agemin > 0");

                entity
                    .HasCheckConstraint("ck_act_prix", "act_prix > 0");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity
                    .HasOne(d => d.Pays)
                    .WithMany(p => p.Villes)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pay_vil");
            });

            modelBuilder.Entity<ActiviteEnfant>(entity =>
            {
                entity
                    .HasBaseType<Activite>();
            });

            modelBuilder.Entity<TypeChambre>(entity =>
            {
                entity
                    .HasCheckConstraint("ck_tch_prix", "tch_prix > 0");
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

            modelBuilder.Entity<ClubCaracteristique>(entity =>
            {
                entity
                    .HasKey(cc => new { cc.IdClub, cc.IdCaracteristique });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubCaracteristiques)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cct");

                entity
                    .HasOne(d => d.Caracteristique)
                    .WithMany(p => p.ClubCaracteristiques)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ctq_cct");
            });

            modelBuilder.Entity<ClubActivite>(entity =>
            {
                entity
                    .HasKey(ca => new { ca.IdClub, ca.IdActivite });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubActivites)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cac");

                entity
                    .HasOne(d => d.Activite)
                    .WithMany(p => p.ClubActivites)
                    .HasForeignKey(d => d.IdActivite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_act_cac");
            });

            modelBuilder.Entity<ClubActiviteEnfant>(entity =>
            {
                entity
                    .HasKey(cae => new { cae.IdClub, cae.IdActiviteEnfant });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubActivitesEnfant)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cae");

                entity
                    .HasOne(d => d.ActiviteEnfant)
                    .WithMany(p => p.ClubActivitesEnfant)
                    .HasForeignKey(d => d.IdActiviteEnfant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ace_cae");
            });

            modelBuilder.Entity<BarMultimedia>(entity =>
            {
                entity
                    .HasKey(bmt => new { bmt.IdBar, bmt.IdMultimedia });

                entity
                    .HasOne(d => d.Bar)
                    .WithMany(p => p.BarMultimedias)
                    .HasForeignKey(d => d.IdBar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bar_bmt");

                entity
                    .HasOne(d => d.Multimedia)
                    .WithMany(p => p.BarMultimedias)
                    .HasForeignKey(d => d.IdMultimedia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mlm_bmt");
            });

            modelBuilder.Entity<RestaurantMultimedia>(entity =>
            {
                entity
                    .HasKey(rmt => new { rmt.IdRestaurant, rmt.IdMultimedia });

                entity
                    .HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantMultimedias)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ret_rmt");

                entity
                    .HasOne(d => d.Multimedia)
                    .WithMany(p => p.RestaurantMultimedias)
                    .HasForeignKey(d => d.IdMultimedia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mlm_rmt");
            });

            modelBuilder.Entity<VilleCodePostal>(entity =>
            {
                entity
                    .HasKey(vcp => new { vcp.IdVille, vcp.IdCodePostal });

                entity
                    .HasOne(d => d.Ville)
                    .WithMany(p => p.VilleCodesPostaux)
                    .HasForeignKey(d => d.IdVille)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vil_vcp");

                entity
                    .HasOne(d => d.CodePostal)
                    .WithMany(p => p.VilleCodesPostaux)
                    .HasForeignKey(d => d.IdCodePostal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cpl_vcp");
            });

            modelBuilder.Entity<ClubPaysLocalisation>(entity =>
            {
                entity
                    .HasKey(cps => new { cps.IdClub, cps.IdPays, cps.IdLocalisation });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubPaysLocalisations)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cps");

                entity
                    .HasOne(d => d.Pays)
                    .WithMany(p => p.ClubPaysLocalisations)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pay_cps");

                entity
                    .HasOne(d => d.Localisation)
                    .WithMany(p => p.ClubPaysLocalisations)
                    .HasForeignKey(d => d.IdLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loc_cps");
            });

            modelBuilder.Entity<PaysLocalisation>(entity =>
            {
                entity
                    .HasKey(pal => new { pal.IdPays, pal.IdLocalisation });

                entity
                    .HasOne(d => d.Pays)
                    .WithMany(p => p.PaysLocalisations)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pay_pal");

                entity
                    .HasOne(d => d.Localisation)
                    .WithMany(p => p.PaysLocalisation)
                    .HasForeignKey(d => d.IdLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loc_pal");
            });

            modelBuilder.Entity<ClubTypeClub>(entity =>
            {
                entity
                    .HasKey(ctc => new { ctc.IdClub, ctc.IdTypeClub });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubTypesClub)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_ctc");

                entity
                    .HasOne(d => d.TypeClub)
                    .WithMany(p => p.ClubTypesClub)
                    .HasForeignKey(d => d.IdTypeClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tcl_ctc");
            });

            modelBuilder.Entity<ClubTypeChambre>(entity =>
            {
                entity
                    .HasKey(cth => new { cth.IdClub, cth.IdTypeChambre });

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.ClubTypesChambre)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_cth");

                entity
                    .HasOne(d => d.TypeChambre)
                    .WithMany(p => p.ClubTypesChambre)
                    .HasForeignKey(d => d.IdTypeChambre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tch_cth");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_rea");

                entity
                    .HasOne(d => d.Transport)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdTransport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trp_rea");

                entity
                    .HasOne(d => d.TypeChambre)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdTypeChambre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tch_rea");

                entity
                    .HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_rea");
            });

            modelBuilder.Entity<Avis>(entity =>
            {
                entity
                    .HasOne(d => d.Client)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_avi");

                entity
                    .HasOne(d => d.Club)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clb_avi");
            });

            modelBuilder.Entity<AvisMultimedia>(entity =>
            {
                entity
                    .HasOne(d => d.Avis)
                    .WithMany(p => p.AvisMultimedias)
                    .HasForeignKey(d => d.IdAvis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avi_amt");

                entity
                    .HasOne(d => d.Multimedia)
                    .WithMany(p => p.AvisMultimedias)
                    .HasForeignKey(d => d.IdMultimedia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mtm_amt");
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
