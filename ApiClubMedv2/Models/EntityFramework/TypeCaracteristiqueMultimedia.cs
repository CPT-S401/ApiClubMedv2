using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_typecaracteristiquemultimedia_tcm", Schema = "clubmed")]
    public class TypeCaracteristiqueMultimedia
    {
        [Required(ErrorMessage = "L'id de type caracteristique est requis")]
        [Column("tcm_idtypecaracteristique")]
        public int IdTypeCaracteristique { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("tcm_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdTypeCaracteristique")]
        [InverseProperty("TypeCaracteristiqueMultimedias")]
        public virtual TypeCaracteristique? TypeCaracteristique { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("TypeCaracteristiqueMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
