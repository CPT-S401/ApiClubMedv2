using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_payslocalisation_pal", Schema = "clubmed")]
    public class PaysLocalisation
    {
        [Required(ErrorMessage = "L'id du pays est requis")]
        [Column("pal_idpays")]
        public int IdPays { get; set; }

        [Required(ErrorMessage = "L'id de la localisation est requis")]
        [Column("pal_idlocalisation")]
        public int IdLocalisation { get; set; }

        [ForeignKey("IdPays")]
        [InverseProperty("PaysLocalisations")]
        public virtual Pays? Pays { get; set; }

        [ForeignKey("IdLocalisation")]
        [InverseProperty("PaysLocalisation")]
        public virtual Localisation? Localisation { get; set; }
    }
}
