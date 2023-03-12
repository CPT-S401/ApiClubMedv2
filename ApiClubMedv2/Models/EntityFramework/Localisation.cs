using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_localisation_loc", Schema = "clubmed")]
    public class Localisation
    {
        public Localisation()
        {
            ClubPaysLocalisation = new HashSet<ClubPaysLocalisation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("loc_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la localisation est requis")]
        [Column("loc_nom")]
        [StringLength(50, ErrorMessage = "La longueur du nom ne doit pas dépasser les 50 caractères")]
        public string Nom { get; set; } = null!;

        [InverseProperty("Localisation")]
        public virtual ICollection<ClubPaysLocalisation> ClubPaysLocalisation { get; set; }
    }
}
