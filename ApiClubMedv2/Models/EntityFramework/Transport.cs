using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_transport_trp", Schema = "clubmed")]
    public class Transport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("trp_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du transport est requis")]
        [Column("trp_nom", TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Le nom du transport ne peut dépasser 50 caractères")]
        public string Nom { get; set; } = null!;

        [Required(ErrorMessage = "Le prix du transport est requis")]
        [Column("trp_prix", TypeName = "numeric(5,2)")]
        public double Prix { get; set; }
    }
}
