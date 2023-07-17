using Domain.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Request
{
    public class MovieRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be null or empty")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Year of Release should not be null or empty")]
        [YearValidation]
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }

        [Required(ErrorMessage = "Actors should not be empty")]
        public string Actors { get; set; }
        public string Genres { get; set; }

        [Required(ErrorMessage = "Producers should not be empty")]
        public int ProducerId { get; set; }

        public string Poster { get; set; }

    }
}
