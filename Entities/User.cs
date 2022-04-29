using System.Text.Json.Serialization;

namespace CRUD_WEB_API.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<MeetUp> Meetups { get; set; }
        public User()
        {
            Meetups = new HashSet<MeetUp>();
        }
    }
}