using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_clubtransport_ctr", Schema = "clubmed")]
    public class ClubTransport
    {
        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("ctr_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id du transport est requis")]
        [Column("ctr_idtransport")]
        public int IdTransport { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ClubTransports")]
        public virtual Club? Club { get; set; }

        [ForeignKey("IdTransport")]
        [InverseProperty("ClubTransports")]
        public virtual Transport? Transport { get; set; }
    }
}
