using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_typeactivite_tac", Schema = "clubmed")]
    public class TypeActivite
    {
        public TypeActivite()
        {
            Activites = new HashSet<Activite>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tac_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du type d'activité est requis")]
        [Column("tac_nom")]
        [StringLength(50, ErrorMessage = "La longueur du nom ne doit pas dépasser les 50 caractères")]
        public string Nom { get; set; } = null!;

        [Column("tac_description")]
        public string? Description { get; set; }

        [InverseProperty("TypeActivite")]
        public virtual ICollection<Activite> Activites { get; set; }
    }
}
