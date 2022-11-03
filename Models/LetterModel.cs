using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace s318344_Assignment1.Models
{
    public class LetterModel
    {
        [Key]
        public int LetterId { get; set; }

        public string letterReference
        {
            get
            {
                return CurrentYear + Student.StudentLastName.ToUpper() + LetterId;
            }
        }

        [Required]
        public int StudentId { get; set; }
        public virtual StudentModel? Student { get; set; }

        [Required]
        public List<LessonModel> Lessons { get; set; }

        [Required]
        public DateTime LetterCreationDate { get; set; }


        // User-entered fields

        [Display(Name = "Opening statement")]
        public string BeginningComment { get; set; }

        [Display(Name = "Signature")]
        [Required]
        public string EmailSignature { get; set; }

        [Display(Name = "Bank")]
        [Required]
        public string BankName { get; set; }
        
        [Display(Name = "Account name")]
        [Required]
        public string BankAccountName { get; set; }

        [Display(Name = "BSB")]
        [Required]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Please enter a valid 6-digit BSB")]
        public string BankAccountBSB { get; set; }

        [Display(Name = "Account number")]
        [Required]
        [RegularExpression(@"^[0-9]$", ErrorMessage = "Please enter a valid account number")]
        public string BankAccountNumber { get; set; }


        //Fields generated as at time of letter generation.

        public int CurrentTerm
        {
            get
            {
                return (LetterCreationDate.Month + 3) / 4;
            }
        }

        //This would be better achieved by having a seperate table that defines term dates. It'll do for now.

        public DateOnly CurrentTermStart
        {
            get
            {
                return (new DateOnly(LetterCreationDate.Year, CurrentTerm, 1));

            }
        }

        //1 month from time letter is created


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly PaymentFinal
        {
            get
            {
                DateTime nextMonth = LetterCreationDate.AddMonths(1);
                return new DateOnly(nextMonth.Year, nextMonth.Month, nextMonth.Day);
            }
        }

        public int CurrentSemester
        {
            get
            {
                return (LetterCreationDate.Month + 5) / 6;
            }
        }

        public int CurrentYear
        {
            get
            {
                return LetterCreationDate.Year;
            }
        }

        [Required]
        [Display(Name = "Outstanding balance")]
        [DataType(DataType.Currency)]
        public float OutstandingBalance
        {
            get
            {
                float balance = 0;

                foreach (LessonModel lesson in Lessons)
                {
                    if (!lesson.Paid)
                    {
                        balance += lesson.LessonType.LessonCost;
                    }

                }

                return balance;
            }
        
        }


        //An invoice will be considered paid if all the related lessons each have a staus of paid.
        public Boolean Paid { 
            
            get
            {
                foreach (LessonModel lesson in Lessons)
                {
                  if (!lesson.Paid)
                    {
                        return false;
                    }
                }
                return true;
            }
                
                
            }

    }
}
