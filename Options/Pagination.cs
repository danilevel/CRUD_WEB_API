using System.ComponentModel.DataAnnotations;

namespace CRUD_WEB_API.Options
{
    public class Pagination
    {
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers!")]
        [Range(1, 100)]
        public int PageNumber { get; set; } = 1;

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers!")]
        [Range(1, 100)]
        public int PageSize { get; set; }
    }
}