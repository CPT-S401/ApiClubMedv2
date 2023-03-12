using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    // [Table("t_e_cookie_cok", Schema = "clubmed")]
    public class Cookie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cok_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du cookie est requis")]
        [Column("cok_nom")]
        [StringLength(50, ErrorMessage = "La longueur du nom du cookie ne doit pas dépasser les 50 caractères")]
        public string Nom { get; set; } = null!;

        [Column("cok_description")]
        public string? Description { get; set; }
    }
}
