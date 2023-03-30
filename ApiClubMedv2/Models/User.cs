namespace ApiClubMedv2.Models
{
    public class User
    {
        public virtual string Email { get; set; } = null!;
        public virtual string Password { get; set; } = null!;
        public virtual string? UserRole { get; set; }
    }
}
