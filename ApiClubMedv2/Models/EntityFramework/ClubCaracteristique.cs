using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubcaracteristique_cct", Schema = "clubmed")]
    public class ClubCaracteristique
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("cct_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id de la caracteristique est requis")]
        [Column("cct_idcaracteristique")]
        public int IdCaracteristique { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubCaracteristiques")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdCaracteristique")]
        [InverseProperty("ClubCaracteristiques")]
        public virtual Caracteristique? Caracteristique { get; set; }
    }
}
