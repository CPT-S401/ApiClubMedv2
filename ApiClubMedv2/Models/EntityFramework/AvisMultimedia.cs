using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_avismultimedia_amt", Schema = "clubmed")]
    public class AvisMultimedia
    {
        [Required(ErrorMessage = "L'id du restaurant est requis")]
        [Column("amt_idavis")]
        public int IdAvis { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("amt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdAvis")]
        [InverseProperty("AvisMultimedias")]
        public virtual Avis? Avis { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("AvisMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
