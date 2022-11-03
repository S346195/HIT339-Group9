using System;
using System.ComponentModel.DataAnnotations;

namespace s318344_Assignment1.Models
{
    public class GenderModel
    {
        [Key]
        public int GenderId { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}
