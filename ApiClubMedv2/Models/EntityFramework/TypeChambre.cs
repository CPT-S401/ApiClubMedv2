using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_typechambre_tch", Schema = "clubmed")]
    public class TypeChambre
    {
        public TypeChambre()
        {
            ClubTypesChambre = new HashSet<ClubTypeChambre>();
            Reservations = new HashSet<Reservation>();
            TypeChambreMultimedias = new HashSet<TypeChambreMultimedia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tch_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'id du club est requis")]
        [Column("tch_idclub")]
        public int IdClub { get; set; }
        
        [Required(ErrorMessage = "Le nom du type de chambre est requis")]
        [Column("tch_nom", TypeName = "varchar(150)")]
        [StringLength(150, ErrorMessage = "La longueur du nom ne doit pas dépasser les 150 caractères")]
        public string Nom { get; set; } = null!;

        [Column("tch_description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix du type de chambre est requis")]
        [Column("tch_prix", TypeName = "numeric(7,2)")]
        public double Prix { get; set; }

        [Column("tch_surface", TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "La longueur de la surface ne doit pas dépasser les 20 caractères")]
        public string? Surface { get; set; }

        [InverseProperty("TypeChambre")]
        public virtual ICollection<ClubTypeChambre> ClubTypesChambre { get; set; }

        [InverseProperty("TypeChambre")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [InverseProperty("TypeChambre")]
        public virtual ICollection<TypeChambreMultimedia> TypeChambreMultimedias { get; set; }
    }
}
