using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_activite_act", Schema = "clubmed")]
    public abstract class Activite
    {
        public Activite()
        {
            ClubActivites = new HashSet<ClubActivite>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du type d'activité est requis")]
        [Column("act_idtypeactivite")]
        public int IdTypeActivite { get; set; }

        [Required(ErrorMessage = "Le nom de l'activité est requis")]
        [Column("act_nom")]
        [StringLength(200, ErrorMessage = "La longueur du nom de l'activité ne doit pas dépasser 200 caractères")]
        public string Nom { get; set; } = null!;

        [Column("act_description")]
        public string? Description { get; set; }

        [Column("act_agemin")]
        public int? AgeMin { get; set; }

        [Column("act_duree")]
        [StringLength(100, ErrorMessage = "La longueur de la durée de l'activité ne doit pas dépasser 100 caractères")]
        public string? Duree { get; set; }

        [Column("act_prix", TypeName = "numeric(7,2)")]
        public double? Prix { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner si l'activité est incluse dans le séjour")]
        [Column("act_estincluse")]
        public bool EstIncluse { get; set; }

        [InverseProperty("Activite")]
        public virtual ICollection<ClubActivite> ClubActivites { get; set; }

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("Activites")]
        public virtual TypeActivite? TypeActivite { get; set; }
    }
}
