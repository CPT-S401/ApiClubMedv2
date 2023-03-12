﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClubMedv2.Models.EntityFramework
{
    [Table("t_e_pays_pay", Schema = "clubmed")]
    public class Pays
    {
        public Pays()
        {
            Villes = new HashSet<Ville>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pay_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du pays est requis")]
        [Column("pay_nom")]
        [StringLength(50, ErrorMessage = "La longueur du nom ne doit pas dépasser les 50 caractères")]
        public string Nom { get; set; } = null!;

        [InverseProperty("Pays")]
        public virtual ICollection<Ville> Villes { get; set; }
    }
}
