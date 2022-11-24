using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group9_Assignment2.Models
{
    public class LetterModel
    {
        [Key]
        public int LetterId { get; set; }

        //Note: This is not a unique reference, would need to add student ID.
        [Display(Name = "Related letter")]
        public string letterReference
        {
            get
            {
                return DateTime.Today.Year + Student.StudentLastName.ToUpper() + LetterId;
            }
        }



        [Required]
        public int StudentId { get; set; }
        public virtual StudentModel? Student { get; set; }

        [Required]
        public List<LessonModel> Lessons { get; set; }

        [Required]
        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LetterCreationDate { get; set; }


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

        public string RawLetterContent
        {
            set
            {
                //Payment link edited to better match the fields in the webpay form
                string PaymentLink = "https://webpay.cdu.edu.au/musicschool/tran?tran-type=006&REFNO="
                                        + letterReference + "&CUSTNAME=" + Student.StudentFullName + "&PARENTSNAME=" + Student.GuardianName + "&UNITAMOUNTINCTAX=" + String.Format("{0:N2}", OutstandingBalance);

                string PaymentHyperlink = "<a href = '" + PaymentLink + "'>link</a>";

                _LetterContent =
                    "<!doctype html><head><meta charset=\"utf-8\"</head><body>"+

                    value   
                    .Replace("{{Student First Name}}", Student.StudentFirstName)
                    .Replace("{{Student Last Name}}", Student.StudentLastName)
                    .Replace("{{Student Full Name}}", Student.StudentFullName)
                    .Replace("{{Guardian}}", Student.GuardianName)
                    .Replace("{{Reference}}", letterReference)
                    .Replace("{{Outstanding Balance}}", String.Format("${0:N2}", OutstandingBalance))
                    .Replace("{{Payment Link}}", PaymentHyperlink)
                    

                +"</body></html>";
            }
        }
        public string _LetterContent { get; set; }

    }
}
