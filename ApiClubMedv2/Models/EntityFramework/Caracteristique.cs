using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_caracteristique_ctq", Schema = "clubmed")]
    public class Caracteristique
    {
        public Caracteristique()
        {
            ClubCaracteristiques = new HashSet<ClubCaracteristique>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ctq_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du type de caractéristique est requis")]
        [Column("ctq_idtypecaracteristique")]
        public int IdTypeCaracteristique { get; set; }

        [Required(ErrorMessage = "Le nom de la caractéristique est requis")]
        [Column("ctq_nom")]
        [StringLength(20, ErrorMessage = "La longueur du nom ne doit pas dépasser les 20 caractères")]
        public string Nom { get; set; } = null!;

        [ForeignKey("IdTypeCaracteristique")]
        [InverseProperty("Caracteristiques")]
        public virtual TypeCaracteristique TypeCaracteristique { get; set; } = null!;

        [InverseProperty("Caracteristique")]
        public virtual ICollection<ClubCaracteristique> ClubCaracteristiques { get; set; }

        [InverseProperty("Caracteristique")]
        public virtual ICollection<CaracteristiqueMultimedia> CaracteristiqueMultimedias { get; set; }

    }
}