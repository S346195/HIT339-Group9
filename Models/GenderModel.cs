using System;
using System.ComponentModel.DataAnnotations;

namespace Group9_Assignment2.Models
{
    public class GenderModel
    {
        [Key]
        public int GenderId { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}
