using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_bar_bar", Schema = "clubmed")]
    public class Bar : Restauration
    {


        [ForeignKey("IdClub")]
        [InverseProperty("Bars")]
        public virtual Club? Club { get; set; }
    }
}
