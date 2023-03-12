using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_restauration_res", Schema = "clubmed")]
    public abstract class Restauration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("res_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("res_idclub")]
        public int IdClub { get; set; }

        [Required(ErrorMessage = "Le nom du bar est requis")]
        [Column("res_nom")]
        [StringLength(200, ErrorMessage = "La longueur du nom de la restauration ne doit pas dépasser 200 caractères")]
        public string Nom { get; set; } = null!;

        [Column("res_description")]
        public string? Description { get; set; }
    }
}
