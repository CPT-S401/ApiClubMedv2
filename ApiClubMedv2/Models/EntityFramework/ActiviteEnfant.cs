using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_activiteenfant_ace", Schema = "clubmed")]
    public class ActiviteEnfant : Activite
    {
        public ActiviteEnfant()
        {
        }

        [Required(ErrorMessage = "L'age maximum de l'activité est requis")]
        [Column("ace_agemax", TypeName = "numeric(4,2)")]
        public double AgeMax { get; set; }

        [InverseProperty("ActiviteEnfant")]
        public virtual Activite? Activite { get; set; }

    }
}
