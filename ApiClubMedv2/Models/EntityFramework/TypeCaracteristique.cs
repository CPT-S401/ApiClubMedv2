using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_typecaracteristique_tct", Schema = "clubmed")]
    public class TypeCaracteristique
    {
        public TypeCaracteristique()
        {
            Caracteristiques = new HashSet<Caracteristique>();
            TypeCaracteristiqueMultimedias = new HashSet<TypeCaracteristiqueMultimedia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ctq_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du type de caractéristique est requis")]
        [Column("ctq_nom")]
        [StringLength(30, ErrorMessage = "La longueur du nom ne doit pas dépasser les 30 caractères")]
        public string Nom { get; set; } = null!;

        [InverseProperty("TypeCaracteristique")]
        public virtual ICollection<Caracteristique> Caracteristiques { get; set; }

        [InverseProperty("TypeCaracteristique")]
        public virtual ICollection<TypeCaracteristiqueMultimedia> TypeCaracteristiqueMultimedias { get; set; }

    }
}
