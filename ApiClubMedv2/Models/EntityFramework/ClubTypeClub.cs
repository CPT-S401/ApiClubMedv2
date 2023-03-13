using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubtypeclub_ctc", Schema = "clubmed")]
    public class ClubTypeClub
    {
        [Required(ErrorMessage = "L'id du pays est requis")]
        [Column("ctc_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de la localisation est requis")]
        [Column("ctc_idtypeclub")]
        public int IdTypeClub { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubTypesClub")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdTypeClub")]
        [InverseProperty("ClubTypesClub")]
        public virtual TypeClub? TypeClub { get; set; }
    }
}
