using System.ComponentModel.DataAnnotations;

namespace FilmLabBackEnd.Models
{
    public class AuthRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}