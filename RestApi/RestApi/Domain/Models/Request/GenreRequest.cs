using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Request
{
    public class GenreRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be null or empty")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
