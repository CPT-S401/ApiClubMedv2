using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_bar_bar", Schema = "clubmed")]
    public class Bar : Restauration
    {
        public Bar()
        {
            BarMultimedias = new HashSet<BarMultimedia>();
        }

        [ForeignKey("IdClub")]
        [InverseProperty("Bars")]
        public virtual Club? Club { get; set; }

        [InverseProperty("Bar")]
        public virtual ICollection<BarMultimedia> BarMultimedias { get; set; }
    }
}
