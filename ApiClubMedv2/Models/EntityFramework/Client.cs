using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ApiClubMedv2.Models.EntityFramework;
using Microsoft.AspNetCore.Identity;
using ApiClubMedv2.Models;

namespace APIClubMed.Models
{
    [Table("t_e_client_clt")]
    [Index("Email", IsUnique = true)]
    [Index("Mobile", IsUnique = true)]
    public class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
            Avis = new HashSet<Avis>();
        }

        private string password;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clt_idclient")]
        public int IdClient { get; set; }

        [Column("clt_genreclient", TypeName = "char(10)")]
        [StringLength(10, ErrorMessage = "Le genre ne doit pas dépasser 10 caractères")]
        [Required(ErrorMessage = "Le genre est requis.")]
        [RegularExpression("^(Monsieur|Madame)$", ErrorMessage = "Le genre doit être Monsieur ou Madame")]
        public string GenreClient { get; set; } = null!;

        [Column("clt_prenomclient", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Required(ErrorMessage = "Le prénom est requis.")]
        public string PrenomClient { get; set; } = null!;

        [Column("clt_nomclient", TypeName = "varchar(50)")]
        [StringLength(50)]
        [Required(ErrorMessage = "Le nom est requis.")]
        public string NomClient { get; set; } = null!;

        [Column("clt_datenaissance", TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de naissance est requis.")]
        //DateNaissance valide seulement si la différence entre la date du jour et la date de naissance est supérieure à 18 ans
        [CustomValidation(typeof(Client), "ValidateAge")]
        public DateTime DateNaissance { get; set; }

        [Column("clt_email", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email doit être une adresse e-mail valide.")]
        //Annotation Regex pour valider le format de l'email
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "L'email doit être une adresse e-mail valide.")]
        [StringLength(100, ErrorMessage = "La longueur d'un email ne doit pas dépasser 100 caractères")]
        public string Email { get; set; } = null!;

        [Column("clt_mobile", TypeName = "char(10)")]
        [Required(ErrorMessage = "Le numéro de téléphone portable est requis.")]
        //Annotation Regex pour valider le format du numéro de téléphone portable en France
        [RegularExpression(@"^((\+)33|0)[1-9](\d{2}){4}$", ErrorMessage = "Le numéro de téléphone portable doit être un numéro valide.")]
        [StringLength(10, ErrorMessage = "Le numéro de téléphone ne doit pas dépasser 10 caractères")]
        public string Mobile { get; set; } = null!;

        [Column("clt_password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est requis.")]
        public string Password
        {
            get { return password; }
            set {
                PasswordHasher pH = new PasswordHasher();
                password = pH.Hash(value);
            }
        }

        [Column("clt_numrue")]
        [StringLength(10, ErrorMessage = "Le numéro de rue ne doit pas dépasser 10 caractères")]
        public string? NumeroRue { get; set; }

        [Column("clt_nomrue")]
        [StringLength(50, ErrorMessage = "Le nom de rue ne doit pas dépasser 50 caractères")]
        public string? NomRue { get; set; }

        [Required(ErrorMessage = "L'id du code postal est requis")]
        [Column("clt_idcodepostal")]
        public int IdCodePostal { get; set; }

        [ForeignKey("IdCodePostal")]
        [InverseProperty("CodePostalDesClients")]
        public virtual CodePostal? CodePostalClient { get; set; }

        /*        [Column("remember_token")]
                [MaxLength(100)]
                public string RememberToken { get; set; }

                [Column("email_verified_at")]
                [DataType(DataType.DateTime)]
                public DateTime? EmailVerifiedAt { get; set; }*/

        public static ValidationResult ValidateAge(DateTime? dateNaissance)
        {
            if (!dateNaissance.HasValue)
            {
                // Si la date de naissance n'est pas renseignée, on ne fait pas la validation
                return ValidationResult.Success;
            }

            // On calcule l'âge de l'utilisateur en fonction de sa date de naissance
            int age = DateTime.Today.Year - dateNaissance.Value.Year;
            if (dateNaissance.Value > DateTime.Today.AddYears(-age))
                age--;

            if (age < 18)
                return new ValidationResult("Vous devez avoir au moins 18 ans pour vous inscrire.");

            return ValidationResult.Success;
        }

        [InverseProperty("Client")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Avis> Avis { get; set; }
    }
}