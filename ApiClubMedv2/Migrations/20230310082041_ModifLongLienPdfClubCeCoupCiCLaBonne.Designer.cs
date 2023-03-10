﻿// <auto-generated />
using System;
using ApiClubMedv2.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    [DbContext(typeof(ClubMedDbContext))]
    [Migration("20230310082041_ModifLongLienPdfClubCeCoupCiCLaBonne")]
    partial class ModifLongLienPdfClubCeCoupCiCLaBonne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiClubMedv2.Models.EntityFramework.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("clb_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("clb_description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("clb_email");

                    b.Property<int?>("IdDomaineSkiable")
                        .HasColumnType("integer")
                        .HasColumnName("clb_iddomaineskiable");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric(14,11)")
                        .HasColumnName("clb_latitude");

                    b.Property<string>("LienPDF")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("clb_lienpdf");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric(14,11)")
                        .HasColumnName("clb_longitude");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("clb_nom");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdDomaineSkiable");

                    b.ToTable("t_e_club_clb", "clubmed");
                });

            modelBuilder.Entity("ApiClubMedv2.Models.EntityFramework.DomaineSkiable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("dsk_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("AltitudeBasse")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("dsk_altitudebasse");

                    b.Property<decimal?>("AltitudeHaute")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("dsk_altitudehaute");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("dsk_description");

                    b.Property<string>("InfoSki")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("dsk_infoski");

                    b.Property<decimal?>("LongeurPistes")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("dsk_longueurpistes");

                    b.Property<decimal?>("NbPistes")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("dsk_nbpistes");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dsk_nom");

                    b.Property<string>("NomStation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dsk_nomstation");

                    b.HasKey("Id");

                    b.ToTable("t_e_domaineskiable_dsk", "clubmed");

                    b.HasCheckConstraint("ck_dsk_altbasse_althaute", "dsk_altitudebasse > 0 and dsk_altitudehaute > dsk_altitudebasse");

                    b.HasCheckConstraint("ck_dsk_longueurpistes", "dsk_longueurpistes > 0");

                    b.HasCheckConstraint("ck_dsk_nombrepistes", "dsk_nbpistes > 0");
                });

            modelBuilder.Entity("ApiClubMedv2.Models.EntityFramework.Multimedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("mtm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("mtm_description");

                    b.Property<int?>("IdClub")
                        .HasColumnType("integer")
                        .HasColumnName("mtm_idclub");

                    b.Property<int?>("IdResto")
                        .HasColumnType("integer")
                        .HasColumnName("mtm_idrestauration");

                    b.Property<string>("Lien")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("mtm_lien");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("mtm_nom");

                    b.HasKey("Id");

                    b.ToTable("t_e_multimedia_mtm", "clubmed");
                });

            modelBuilder.Entity("ApiClubMedv2.Models.EntityFramework.Club", b =>
                {
                    b.HasOne("ApiClubMedv2.Models.EntityFramework.DomaineSkiable", "Domaine")
                        .WithMany("Clubs")
                        .HasForeignKey("IdDomaineSkiable")
                        .HasConstraintName("fk_clb_dsk");

                    b.Navigation("Domaine");
                });

            modelBuilder.Entity("ApiClubMedv2.Models.EntityFramework.DomaineSkiable", b =>
                {
                    b.Navigation("Clubs");
                });
#pragma warning restore 612, 618
        }
    }
}
