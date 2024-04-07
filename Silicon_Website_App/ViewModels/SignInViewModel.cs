using Silicon_Website_App.Models;

namespace Silicon_Website_App.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public SignInFormModel Form { get; set; } = new SignInFormModel();

    public string? ErrorMessage { get; set; }
}
