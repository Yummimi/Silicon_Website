using System.ComponentModel.DataAnnotations;

namespace Silicon_Website_App.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public string? ErrorMessage { get; set; }



    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 0)]
    public string Email { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    public string Password { get; set; } = null!;


    [Display(Name = "Remember me", Order = 2)]
    public bool RememberMe { get; set; }
}
