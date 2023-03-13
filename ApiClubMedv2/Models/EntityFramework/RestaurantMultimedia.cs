using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_j_restaurantmultimedia_rmt", Schema = "clubmed")]
    public class RestaurantMultimedia
    {
        [Required(ErrorMessage = "L'id du restaurant est requis")]
        [Column("rmt_idrestaurant")]
        public int IdRestaurant { get; set; }

        [Required(ErrorMessage = "L'id du multimedia est requis")]
        [Column("rmt_idmultimedia")]
        public int IdMultimedia { get; set; }

        [ForeignKey("IdRestaurant")]
        [InverseProperty("RestaurantMultimedias")]
        public virtual Restaurant? Restaurant { get; set; }

        [ForeignKey("IdMultimedia")]
        [InverseProperty("RestaurantMultimedias")]
        public virtual Multimedia? Multimedia { get; set; }
    }
}
