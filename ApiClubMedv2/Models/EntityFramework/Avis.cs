using APIClubMed.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_avis_avi", Schema = "clubmed")]
    public class Avis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("avi_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du client est requis")]
        [Column("avi_idclient")]
        public int IdClient { get; set; }

        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("avi_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "La note de l'avis est requise")]
        [Column("avi_note")]
        [Range(0, 5, ErrorMessage = "La note doit être comprise entre 0 et 5")]
        public int Note { get; set; }

        [Column("avi_commentaire")]
        public string? Commentaire { get; set; }

        [Column("avi_dateenvoi")]
        public DateTime DateEnvoi { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty("Avis")]
        public virtual Client Client { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("Avis")]
        public virtual Club Club { get; set; }
    }
}
