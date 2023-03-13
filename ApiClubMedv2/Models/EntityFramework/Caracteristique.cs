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

        [Required(ErrorMessage = "Le nom de la caract�ristique est requis")]
        [Column("ctq_nom")]
        [StringLength(20, ErrorMessage = "La longueur du nom ne doit pas d�passer les 20 caract�res")]
        public string Nom { get; set; } = null!;

        [Column("ctq_lienicon", TypeName = "varchar(255)")]
        [StringLength(255, ErrorMessage = "La longueur d'un lien ne doit pas d�passer 255 caract�res")]
        public string? Icon { get; set; }

        [InverseProperty("Caracteristique")]
        public virtual ICollection<ClubCaracteristique> ClubCaracteristiques { get; set; }
    }
}