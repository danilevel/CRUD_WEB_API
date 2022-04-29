using System.ComponentModel.DataAnnotations;

namespace CRUD_WEB_API.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}