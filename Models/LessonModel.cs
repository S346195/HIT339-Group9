using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace s318344_Assignment1.Models
{
    public class LessonModel
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual StudentModel? Student { get; set; }

        [Required]
        public int TutorId { get; set; }
        public virtual TutorModel? Tutor { get; set; }

        [ForeignKey("LessonTypeModel")]
        public int? LessonTypeId { get; set; }

        [Display(Name ="Type")]
        public virtual LessonTypeModel? LessonType { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Date & time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime LessonDateTime { get; set; }

        [Display(Name = "Year")]
        public int LessonYear => LessonDateTime.Year;

        [Display(Name = "Term")]
        public int LessonTerm => (LessonDateTime.Month + 2) / 3;

        [Display(Name = "Semester")]
        public int LessonSemester => (LessonDateTime.Month + 5) / 6;

        public Boolean Paid { get; set; }

        public int? LetterId { get; set; }
        public virtual LetterModel? Letter { get; set; }

    }
}
