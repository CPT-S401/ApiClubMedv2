using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubtypechambre_cth", Schema = "clubmed")]
    public class ClubTypeChambre
    {
        [Required(ErrorMessage = "L'id du pays est requis")]
        [Column("cth_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de la localisation est requis")]
        [Column("cth_idtypechambre")]
        public int IdTypeChambre { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubTypesChambre")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("ClubTypesChambre")]
        public virtual TypeChambre? TypeChambre { get; set; }
    }
}
