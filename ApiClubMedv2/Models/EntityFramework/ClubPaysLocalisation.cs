using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubpayslocalisation_cps", Schema = "clubmed")]
    public class ClubPaysLocalisation
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("cps_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id du pays est requis")]
        [Column("cps_idpays")]
        public int IdPays { get; set; }

        [Required(ErrorMessage = "L'id de la localisation est requis")]
        [Column("cps_idlocalisation")]
        public int IdLocalisation { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubPaysLocalisations")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdPays")]
        [InverseProperty("ClubPaysLocalisations")]
        public virtual Pays? Pays { get; set; }

        [ForeignKey("IdLocalisation")]
        [InverseProperty("ClubPaysLocalisations")]
        public virtual Localisation? Localisation { get; set; }
    }
}
