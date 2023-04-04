using ApiClubMedv2.Models.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiClubMedv2.Models
{
    public class User
    {
        public virtual string Email { get; set; } = null!;
        public virtual string Password { get; set; } = null!;
        public virtual string? UserRole { get; set; }
    }
}
