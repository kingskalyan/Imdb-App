using Domain.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Request
{
    public class ProducerRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should be null or empty")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Bio { get; set; }

        [Required(ErrorMessage = "Date of Birth should not be null")]
        [YearValidation]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
