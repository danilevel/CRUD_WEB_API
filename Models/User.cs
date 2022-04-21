using Microsoft.AspNetCore.Identity;

namespace CRUD_WEB_API.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}