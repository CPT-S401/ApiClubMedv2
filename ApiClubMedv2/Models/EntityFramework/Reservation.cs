using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_reservation_rea")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("rea_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du client est requis")]
        [Column("rea_idclient")]
        public int IdClient { get; set; }

        [Column("rea_idtransport")]
        public int? IdTransport { get; set; }

        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("rea_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "L'id du type chambre de la réservation est requise")]
        [Column("rea_idtypechambre")]
        public int IdTypeChambre { get; set; }

        [Required(ErrorMessage = "La date de début de la réservation est requise")]
        [Column("rea_datedebut", TypeName = "date")]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "La date de fin de la réservation est requise")]
        [Column("rea_datefin", TypeName = "date")]
        public DateTime DateFin { get; set; }

        [Required(ErrorMessage = "La date de la réservation est requise")]
        [Column("rea_date", TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
