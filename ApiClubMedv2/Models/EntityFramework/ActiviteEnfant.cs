﻿multimedia

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_activiteenfant_ace", Schema = "clubmed")]
    public class ActiviteEnfant : Activite
    {
        public ActiviteEnfant()
        {
            ClubActivitesEnfant = new HashSet<ClubActiviteEnfant>();
        }

        [Required(ErrorMessage = "L'age maximum de l'activité est requis")]
        [Column("ace_agemax")]
        public double AgeMax { get; set; }

        [InverseProperty("ActiviteEnfant")]
        public virtual ICollection<ClubActiviteEnfant> ClubActivitesEnfant { get; set; }
    }
}
