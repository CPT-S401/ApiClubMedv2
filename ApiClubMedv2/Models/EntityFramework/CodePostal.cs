using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_codepostal_cpl", Schema = "clubmed")]
    public class CodePostal
    {
        public CodePostal()
        {
            VilleCodesPostaux = new HashSet<VilleCodePostal>();
        }

        public CodePostal(string code)
        {
            this.Code = code;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cpl_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code postal est requis")]
        [Column("cpl_nom")]
        [StringLength(10, ErrorMessage = "La longueur du nom ne doit pas dépasser les 10 caractères")]
        public string Code { get; set; } = null!;

        [InverseProperty("CodePostal")]
        public virtual ICollection<VilleCodePostal> VilleCodesPostaux { get; set; }
    }
}
