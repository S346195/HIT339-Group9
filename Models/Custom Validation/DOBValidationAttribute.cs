//Adapted from https://techfunda.com/howto/264/custom-validation-in-asp-net-mvc

using System.ComponentModel.DataAnnotations;
public class DOBValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime todayDate = Convert.ToDateTime(value);
        return todayDate <= DateTime.Now;
    }
}