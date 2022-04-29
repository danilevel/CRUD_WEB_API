namespace CRUD_WEB_API.Models
{
    public class MeetUpDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}