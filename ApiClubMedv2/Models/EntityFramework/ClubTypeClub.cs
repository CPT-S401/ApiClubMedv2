using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubtypeclub_ctc", Schema = "clubmed")]
    public class ClubTypeClub
    {
        [Required(ErrorMessage = "L'id du pays est requis")]
        [Column("pal_idpays")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de la localisation est requis")]
        [Column("pal_idlocalisation")]
        public int IdTypeClub { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubTypesClub")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdTypeClub")]
        [InverseProperty("ClubTypesClub")]
        public virtual TypeClub? TypeClub { get; set; }
    }
}
