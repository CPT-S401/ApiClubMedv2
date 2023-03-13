using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_typeclub_tcl", Schema = "clubmed")]
    public class TypeClub
    {
        public TypeClub()
        {
            ClubTypesClub = new HashSet<ClubTypeClub>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tcl_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du type de club est requis")]
        [Column("tcl_nom")]
        [StringLength(20, ErrorMessage = "La longueur du nom ne doit pas dépasser les 20 caractères")]
        public string Nom { get; set; } = null!;

        [InverseProperty("TypeClub")]
        public virtual ICollection<ClubTypeClub> ClubTypesClub { get; set; }
    }
}
