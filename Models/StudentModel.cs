using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group9_Assignment2.Models
{
    public class StudentModel
    {
        [Key]
        [Display(Name = "Student number")]
        public int StudentID { get; set; }

        [Required]
        [StringLength(200)]
        [RegularExpression(@"^[a-zA-Z\-\\s]*$", ErrorMessage = "Please enter a valid name e.g John")]
        [Display(Name = "First name")]
        public string StudentFirstName { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z\-\\s]*$", ErrorMessage = "Please enter a valid name e.g Smith")]
        public string StudentLastName { get; set; }

        [Display(Name = "Student")]
        public string StudentFullName
        {
            get { return StudentFirstName + " " + StudentLastName; }
        }

        [DataType(DataType.Date)]
        [Required]
        [DOBValidation(ErrorMessage = "Date of birth cannot be greater than today.")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        public int Age
        {
            get

            {
                DateTime now = DateTime.Today;
                int age = now.Year - DOB.Year;
                if (DOB > now.AddYears(-age)) age--;
                return age;
            }

        }

        [ForeignKey("GenderModel")]
        [Display(Name ="Gender")]
        public int GenderId { get; set; }
        public virtual GenderModel? Gender { get; set; }   


        [Required]
        [Display(Name = "Parent / Guardian")]
        [StringLength(200)]
        public string GuardianName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Guardian email")]
        public string PaymentContactEmail { get; set; }


        [Required]
        [Display(Name = "Guardian phone")]
        [Phone]
        [RegularExpression(@"^0[1-9][0-9]{8}$", ErrorMessage = "Please enter a valid 10 digit phone or mobile number.")]
        public string PaymentContactNumber { get; set; }

        public virtual List<LessonModel>? Lessons { get; set; }

    }
}
