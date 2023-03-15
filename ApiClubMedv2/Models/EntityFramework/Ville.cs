using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_ville_vil", Schema = "clubmed")]
    public class Ville
    {
        public Ville()
        {
            VilleCodesPostaux = new HashSet<VilleCodePostal>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("vil_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la ville est requis")]
        [Column("vil_nom")]
        [StringLength(100, ErrorMessage = "La longueur du nom ne doit pas dépasser les 100 caractères")]
        public string Nom { get; set; } = null!;

        [Required(ErrorMessage = "L'id du pays de la ville est requis")]
        [Column("vil_idpays")]
        public int IdPays { get; set; }

        [ForeignKey("IdPays")]
        [InverseProperty("Villes")]
        public virtual Pays? Pays { get; set; }

        [InverseProperty("Ville")]
        public virtual ICollection<VilleCodePostal> VilleCodesPostaux { get; set; }
    }
}
