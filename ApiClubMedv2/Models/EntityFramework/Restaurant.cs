using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_restaurant_ret", Schema = "clubmed")]
    public class Restaurant : Restauration
    {
        public Restaurant()
        {
            RestaurantMultimedias = new HashSet<RestaurantMultimedia>();
        }

        [ForeignKey("IdClub")]
        [InverseProperty("Restaurants")]
        public virtual Club? Club { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<RestaurantMultimedia> RestaurantMultimedias { get; set; }
    }
}
