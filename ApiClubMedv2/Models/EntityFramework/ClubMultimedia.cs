using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubmultimedia_cmt", Schema = "clubmed")]
    public class ClubMultimedia
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("cmt_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("cmt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubMultimedias")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("ClubMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
