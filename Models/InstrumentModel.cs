using System;
using System.ComponentModel.DataAnnotations;

namespace s318344_Assignment1.Models
{
    public class InstrumentModel
    {
        [Key]

        [Display(Name ="Serial number")]
        public int InstrumentId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string Instrument
        {
            get
            {
                return Make + " " + Model;
            }
        }

        public ICollection<LessonModel>? Lessons { get; set; }

    }
}
