using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_typeactivitemultimedia_tam", Schema = "clubmed")]
    public class TypeActiviteMultimedia
    {
        [Required(ErrorMessage = "L'id du type activite est requis")]
        [Column("tcm_idtypecaracteristique")]
        public int IdTypeActivite { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("tcm_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("TypeActiviteMultimedias")]
        public virtual TypeActivite? TypeActivite { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("TypeActiviteMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}