using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_caracteristiquemultimedia_cmt", Schema = "clubmed")]
    public class CaracteristiqueMultimedia
    {
        [Required(ErrorMessage = "L'id de caracteristique est requis")]
        [Column("cmt_idcaracteristique")]
        public int IdCaracteristique { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("cmt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdCaracteristique")]
        [InverseProperty("CaracteristiqueMultimedias")]
        public virtual Caracteristique? Caracteristique { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("CaracteristiqueMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
