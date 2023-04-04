using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_typechambremultimedia_thm", Schema = "clubmed")]
    public class TypeChambreMultimedia
    {
        [Required(ErrorMessage = "L'id de type chambre est requis")]
        [Column("thm_idtypechambre")]
        public int IdTypeChambre{ get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("thm_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("TypeChambreMultimedias")]
        public virtual TypeChambre? TypeChambre{ get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("TypeChambreMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}