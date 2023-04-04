using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_activitemultimedia_atm", Schema = "clubmed")]
    public class ActiviteMultimedia
    {
        [Required(ErrorMessage = "L'id de l'activite est requis")]
        [Column("atm_idactivite")]
        public int IdActivite { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("atm_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdActivite")]
        [InverseProperty("ActiviteMultimedias")]
        public virtual Activite? Activite { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("ActiviteMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}