using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_restaurant_ret")]
    public class Restaurant : Restauration
    {
        [ForeignKey("IdClub")]
        [InverseProperty("Restaurants")]
        public virtual Club? Club { get; set; }
    }
}
