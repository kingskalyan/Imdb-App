using Domain.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Request
{
    public class ActorRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be null or empty")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Bio { get; set; }

        [Required(ErrorMessage = "Date of Birth should not be null or empty")]
        [YearValidation]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

    }
}
