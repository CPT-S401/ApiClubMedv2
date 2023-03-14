using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_multimedia_mtm", Schema = "clubmed")]
    public class Multimedia
    {
        public Multimedia()
        {
            ClubMultimedias = new HashSet<ClubMultimedia>();
            BarMultimedias = new HashSet<BarMultimedia>();
            RestaurantMultimedias = new HashSet<RestaurantMultimedia>();
            AvisMultimedias = new HashSet<AvisMultimedia>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mtm_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du fichier multimedia est requis")]
        [Column("mtm_nom", TypeName = "varchar(150)")]
        [StringLength(150, ErrorMessage = "Le nom du fichier multimedia ne peut dépasser 150 caractères")]
        public string Nom { get; set; } = null!;

        [Column("mtm_description", TypeName = "text")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le lien du fichier multimedia est requis")]
        [Column("mtm_lien", TypeName = "varchar(200)")]
        [StringLength(200, ErrorMessage = "Le nom du fichier multimedia ne peut dépasser 200 caractères")]
        public string Lien { get; set; } = null!;

        [InverseProperty("Multimedia")]
        public virtual ICollection<ClubMultimedia> ClubMultimedias { get; set; }

        [InverseProperty("Multimedia")]
        public virtual ICollection<BarMultimedia> BarMultimedias { get; set; }

        [InverseProperty("Multimedia")]
        public virtual ICollection<RestaurantMultimedia> RestaurantMultimedias { get; set; }

        [InverseProperty("Multimedia")]
        public virtual ICollection<AvisMultimedia> AvisMultimedias { get; set; }
    }
}
