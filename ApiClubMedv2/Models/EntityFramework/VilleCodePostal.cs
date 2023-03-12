using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_villecodepostal_vcp", Schema = "clubmed")]
    public class VilleCodePostal
    {
        [Required(ErrorMessage = "L'id de la ville est requis")]
        [Column("rmt_idrestaurant")]
        public int IdVille { get; set; }

        [Required(ErrorMessage = "L'id du code postal est requis")]
        [Column("rmt_idmultimedia")]
        public int IdCodePostal { get; set; }

        [ForeignKey("IdVille")]
        [InverseProperty("VilleCodesPostaux")]
        public virtual Ville? Ville { get; set; }

        [ForeignKey("IdCodePostal")]
        [InverseProperty("VilleCodesPostaux")]
        public virtual CodePostal? CodePostal { get; set; }
    }
}
