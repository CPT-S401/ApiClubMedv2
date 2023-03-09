using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_club_clb", Schema = "clubmed")]
    public class Club
    {
        [Key]
        [Column("clb_id")]
        public int Id { get; set; }

        [Required]
        [Column("clb_iddomaineskiable")]
        public int IdDomaineSkiable { get; set; }

        [Required]
        [Column("clb_nom")]
        [StringLength(50)]
        public string Nom { get; set; } = null!;

        [Column("clb_description", TypeName = "text")]
        public string Description { get; set; } = null!;

        [Required]
        [Column("clb_longitude", TypeName = "numeric(14,11)")]
        public decimal Longitude { get; set; }

        [Required]
        [Column("clb_latitude", TypeName = "numeric(14,11)")]
        public decimal Latitude { get; set; }

        /*[ForeignKey("IdDomaineSkiable")]
        public DomaineSkiable DomaineSkiable { get; set; } = null!;*/
    }
}
