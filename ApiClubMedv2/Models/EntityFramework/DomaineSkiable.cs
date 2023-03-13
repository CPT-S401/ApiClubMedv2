using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_domaineskiable_dsk", Schema = "clubmed")]
    public class DomaineSkiable
    {
        public DomaineSkiable()
        {
            Clubs = new HashSet<Club>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("dsk_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du domaine skiable est requis")]
        [Column("dsk_nom", TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "La longueur du nom de domaine ne peut dépasser 50 caractères")]
        public string Nom { get; set; } = null!;

        [Column("dsk_description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le nom de la station du domaine skiable est requis")]
        [Column("dsk_nomstation", TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "La longueur du nom de la station ne peut dépasser 50 caractères")]
        public string NomStation { get; set; } = null!;

        [Column("dsk_altitudebasse", TypeName = "numeric(6,2)")]
        public double? AltitudeBasse { get; set; }

        [Column("dsk_altitudehaute", TypeName = "numeric(6,2)")]
        public double? AltitudeHaute { get; set; }

        [Column("dsk_longueurpistes", TypeName = "numeric(3,0)")]
        public double? LongeurPistes { get; set; }

        [Column("dsk_nbpistes", TypeName = "numeric(3,0)")]
        public double? NbPistes { get; set; }

        [Column("dsk_infoski", TypeName = "varchar(200)")]
        [StringLength(50, ErrorMessage = "La longueur de l'info ski ne peut dépasser 200 caractères.")]
        public string? InfoSki { get; set; }

        [InverseProperty("Domaine")]
        public virtual ICollection<Club> Clubs { get; set; }
    }
}
