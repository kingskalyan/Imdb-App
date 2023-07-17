using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Request
{
    public class ReviewRequest
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        [Required(ErrorMessage = "Movie Model should not be null or empty")]
        public int MovieId { get; set; }
    }
}
