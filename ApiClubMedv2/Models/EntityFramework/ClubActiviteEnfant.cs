using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubactiviteenfant_cae", Schema = "clubmed")]
    public class ClubActiviteEnfant
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("cae_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de l'activité est requis")]
        [Column("cae_idactiviteenfant")]
        public int IdActiviteEnfant { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubActivitesEnfant")]
        public virtual Club? Club { get; set; }
    }
}
