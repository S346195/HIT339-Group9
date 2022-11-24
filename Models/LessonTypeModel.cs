using System;
using System.ComponentModel.DataAnnotations;

namespace Group9_Assignment2.Models
{

    //LessonTypeModel === Duration
    public class LessonTypeModel
    {
        [Key]
        public int LessonTypeId { get; set; }

        [Required]
        [Display(Name = "Lesson type")]
        public string LessonType { get; set; }

        [Required]
        [Display(Name = "Duration (in minutes)")]
        public int LessonDuration { get; set; }

        [Required]
        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public float LessonCost { get; set; }

        public string LessonTypeFullName
        {
            get
            {
                return LessonType + " (" + LessonDuration + " minutes | $" + LessonCost+")";
            }
        }


    }
}
