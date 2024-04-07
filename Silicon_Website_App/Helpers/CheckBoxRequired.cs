using System.ComponentModel.DataAnnotations;

namespace Silicon_Website_App.Helpers;

public class CheckBoxRequired : ValidationAttribute
{

    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}