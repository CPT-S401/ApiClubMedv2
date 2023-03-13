using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_club_clb", Schema = "clubmed")]
    public class Club
    {
        public Club()
        {
            ClubMultimedias = new HashSet<ClubMultimedia>();
            ClubTransports = new HashSet<ClubTransport>();
            ClubCaracteristiques = new HashSet<ClubCaracteristique>();
            ClubActivites = new HashSet<ClubActivite>();
            ClubActivitesEnfant = new HashSet<ClubActiviteEnfant>();
            Bars = new HashSet<Bar>();
            Restaurants = new HashSet<Restaurant>();
            ClubPaysLocalisations = new HashSet<ClubPaysLocalisation>();
            ClubTypeClubs = new HashSet<ClubTypeClub>();
            ClubTypesChambre = new HashSet<ClubTypeChambre>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clb_id")]
        public int Id { get; set; }

        [Column("clb_iddomaineskiable")]
        public int? IdDomaineSkiable { get; set; }

        [Required(ErrorMessage = "Le nom du club est requis")]
        [Column("clb_nom")]
        [StringLength(100, ErrorMessage = "La longueur du nom ne doit pas dépasser les 100 caractères")]
        public string Nom { get; set; } = null!;

        [Column("clb_description", TypeName = "text")]
        public string? Description { get; set; }
        
        [Column("clb_lienpdf", TypeName = "varchar(255)")]
        [StringLength(255, ErrorMessage = "La longueur d'un lien ne doit pas dépasser 255 caractères")]
        public string? LienPDF { get; set; }

        [Required(ErrorMessage = "La longitude est requise")]
        [Column("clb_longitude", TypeName = "numeric(14,11)")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "La latitude est requise")]
        [Column("clb_latitude", TypeName = "numeric(14,11)")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [Column("clb_email", TypeName = "varchar(100)")]
        [EmailAddress(ErrorMessage = "L'email doit être une adresse e-mail valide.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "L'email doit être une adresse e-mail valide.")]
        [StringLength(100, ErrorMessage = "La longueur d'un email ne doit pas dépasser 100 caractères")]
        public string Email { get; set; } = null!;

        [ForeignKey("IdDomaineSkiable")]
        [InverseProperty("Clubs")]
        public virtual DomaineSkiable? Domaine { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubMultimedia> ClubMultimedias { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubTransport> ClubTransports { get; set; }
        
        [InverseProperty("Club")]
        public virtual ICollection<ClubCaracteristique> ClubCaracteristiques { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubActivite> ClubActivites { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubActiviteEnfant> ClubActivitesEnfant { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<Bar> Bars { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubPaysLocalisation> ClubPaysLocalisations { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubTypeClub> ClubTypeClubs { get; set; }

        [InverseProperty("Club")]
        public virtual ICollection<ClubTypeChambre> ClubTypesChambre { get; set; }
    }
}
