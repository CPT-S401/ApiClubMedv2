using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_domainemultimedia_dmt", Schema = "clubmed")]
    public class DomaineMultimedia
    {
        [Required(ErrorMessage = "L'id du domaine skiable est requis")]
        [Column("dmt_iddomaineskiable")]
        public int IdDomaineSkiable { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("dmt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdDomaineSkiable")]
        [InverseProperty("DomaineMultimedias")]
        public virtual DomaineSkiable? Domaine { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("DomaineMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }

        
    }
}