using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubactivite_cac", Schema = "clubmed")]
    public class ClubActivite
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("cac_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de l'activité est requis")]
        [Column("cac_idactivite")]
        public int IdActivite { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubActivites")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdActivite")]
        [InverseProperty("ClubActivites")]
        public virtual Activite? Activite { get; set; }
    }
}
