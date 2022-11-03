using System;
using System.ComponentModel.DataAnnotations;

namespace s318344_Assignment1.Models
{
    public class TutorModel
    {
        [Key]
        public int TutorId { get; set; }

        [Required]
        [Display(Name ="Tutor")]
        public string TutorName { get; set; }

        public ICollection<LessonModel>? Lessons { get; set; }

    }
}
