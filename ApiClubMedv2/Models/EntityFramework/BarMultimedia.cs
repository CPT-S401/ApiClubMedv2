using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_barmultimedia_bmt", Schema = "clubmed")]
    public class BarMultimedia
    {
        [Required(ErrorMessage = "L'id du bar est requis")]
        [Column("bmt_idbar")]
        public int IdBar { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("bmt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdBar")]
        [InverseProperty("BarMultimedias")]
        public virtual Bar? Bar { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("BarMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
